using UnityEngine;

public class Fly : MonoBehaviour
{
    
    [Header("Zeppelin Tuning")]
    public float floatiness = 1.0f;
    public float dragReduction = 1.0f;
    public float handling = 1.0f;
    public float acceleration = 1.0f;

    private float acceletationMultplier = .15f;
    private float dragMultiplier = .05f;
    private float floatinessMultiplier = 1f;
    private float rotationMultiplier = .6f;
    private float currentSpeed;
    private Rigidbody body;

    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public Terminal t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        body.linearVelocity = Vector3.forward*10;
        body.linearDamping = dragMultiplier/dragReduction;
        t = GameObject.Find("Terminal").GetComponent<Terminal>();
    }

    private void ApplyInputs()
    {
        bool forward = (Input.GetKey("w") || Input.GetKey("u") || Input.GetKey("up"));
        bool back = (Input.GetKey("s") || Input.GetKey("j") || Input.GetKey("down"));

        bool right = (Input.GetKey("d") || Input.GetKey("k") || Input.GetKey("right"));
        bool left = (Input.GetKey("a") || Input.GetKey("h") || Input.GetKey("left"));

        bool accelerate = Input.GetMouseButton(0);
        bool decelerate = Input.GetMouseButton(1);

        float rotSpeed = rotationMultiplier * handling;
        if(forward) transform.Rotate(rotSpeed, 0f, 0f, Space.Self);
        if(back) transform.Rotate(-rotSpeed, 0f, 0f, Space.Self);
        if(right) transform.Rotate(0f, 0, -rotSpeed, Space.Self);
        if(left) transform.Rotate(0f, 0, rotSpeed, Space.Self);

        if (accelerate) currentSpeed += acceleration* acceletationMultplier;
        if (decelerate) currentSpeed -= acceleration* acceletationMultplier;
        if(accelerate && !decelerate)
        {
            ps1.Play();
            ps2.Play();
        } else
        {
            ps1.Pause();
            ps2.Pause();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.LogError("Ouchie wouchie");
        t.life--;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        currentSpeed = body.linearVelocity.magnitude;
        Debug.Log(currentSpeed);
        ApplyInputs();
        body.linearVelocity = transform.forward * currentSpeed;

    }
}
