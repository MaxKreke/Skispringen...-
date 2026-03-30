using UnityEngine;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour
{
    
    [Header("Zeppelin Tuning")]
    //public float floatiness = 1.0f;
    public float dragReduction = 1.0f;
    public float handling = 1.0f;
    public float acceleration = 1.0f;

    private float acceletationMultplier = .15f;
    private float dragMultiplier = .05f;
    //private float floatinessMultiplier = 1f;
    private float rotationMultiplier = .6f;
    private float currentSpeed;
    private Rigidbody body;

    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem pps;
    public Terminal t;
    public SetDirection sd;
    public Transform target;
    public Camera mainCam;

    //0 = Studio
    //1 = Bakery
    //2 = Octopus Garden
    //3 = Bird Park
    //4 = Shangri La
    //5 = The Staircase
    private Vector3[] locationCoordinates =
    {
        new Vector3(0,20,0),
        new Vector3(4939,3013,-6612),
        new Vector3(-4958,21,-6616),
        new Vector3(-7931,4024,2008),
        new Vector3(-6,8040,8072),
        new Vector3(7877,9987,2019),
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        body = GetComponent<Rigidbody>();

        t = GameObject.Find("Terminal").GetComponent<Terminal>();

        dragReduction = (float)t.integerFlags[3].value;
        handling = computeHandling(t.integerFlags[1].value);
        acceleration = (float)t.integerFlags[0].value;

        if (t.tutorialStage > 0)
        {
            body.linearVelocity = Vector3.forward * 10;
            transform.position = locationCoordinates[t.location];
            transform.LookAt(locationCoordinates[t.targetLocation]);
            if (target != null)
            {
                target.gameObject.GetComponent<Hoop>().Start();
            }
        }
        mainCam = Camera.main;
    }

    private float computeHandling(int flag)
    {
        return (1f + 2f * (Mathf.Log((float)flag) / Mathf.Log(5)));
    }

    private void ApplyInputs()
    {
        bool accelerate = Input.GetMouseButton(0);
        bool decelerate = Input.GetMouseButton(1);

        bool forward = (Input.GetKey("w") || Input.GetKey("u") || Input.GetKey("up"));
        bool back = (Input.GetKey("s") || Input.GetKey("j") || Input.GetKey("down"));


        bool right = (Input.GetKey("d") || Input.GetKey("k") || Input.GetKey("right"));
        bool left = (Input.GetKey("a") || Input.GetKey("h") || Input.GetKey("left"));

        //Limited Tutorial Controls
        if (t.tutorialStage < 1)
        {
            forward = false;
            back = false;
        }
        if (t.tutorialStage < 3)
        {
            right = false;
            left = false;
        }

        float rotSpeed = rotationMultiplier * handling;
        if(forward) transform.Rotate(rotSpeed, 0f, 0f, Space.Self);
        if(back) transform.Rotate(-rotSpeed, 0f, 0f, Space.Self);
        if(right) transform.Rotate(0f, 0, -rotSpeed, Space.Self);
        if(left) transform.Rotate(0f, 0, rotSpeed, Space.Self);

        if (accelerate) currentSpeed += acceleration* acceletationMultplier;
        if (decelerate) currentSpeed -= acceleration* acceletationMultplier;

        //Calculate drag
        float drag;

        if(forward || back)
        {
            drag = 2*dragMultiplier / dragReduction;
        } else
        {
            drag = dragMultiplier / dragReduction;
        }
        if (decelerate) drag = drag * acceleration * 2;

        body.linearDamping = drag;

        if (accelerate && !decelerate)
        {
            ps1.Play();
            ps2.Play();
            pps.Play();
        } else
        {
            ps1.Pause();
            ps2.Pause();
            pps.Pause();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(2);
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject otherO = other.gameObject;
        string tag = otherO.tag;

        if(tag == "Hoop")
        {
            Hoop hoop = otherO.GetComponent<Hoop>();
            target = hoop.next.transform;
            hoop.Trigger();
        }
        else if (tag == "Location")
        {
            if (otherO.transform != target)
            {
                SceneManager.LoadScene(2);
                return;
            }
            int lvlIdx = otherO.GetComponent<Location>().idx;
            t.location = lvlIdx;
            SceneManager.LoadScene(3);
        }
        else if (tag == "Tutorial")
        {
            GameObject.Find("Tutorial").GetComponent<Tutorial>().Next();
        }

    }

    void SetDirection()
    {
        if(target == null)
        {
            return;
        }
        Transform camT = mainCam.gameObject.transform;
        Vector3 dir = (target.position - camT.position).normalized;
        Vector3 localDir = camT.InverseTransformDirection(dir);

        float absX = Mathf.Abs(localDir.x);
        float absY = Mathf.Abs(localDir.y);
        float absZ = Mathf.Abs(localDir.z);

        //Z am größten
        if(absZ > absY && absZ > absX)
        {
            if (localDir.z > 0)sd.Front();
            else sd.Back();
            return;
        }
        //Y am größten
        else if (absX < absY)
        {
            if (localDir.y > 0)sd.Up();
            else sd.Down();
            return;
        }
        //X am größten
        else
        {
            if (localDir.x > 0)sd.Right();
            else sd.Left();
            return;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        SetDirection();
    }

    private void FixedUpdate()
    {
        currentSpeed = body.linearVelocity.magnitude;
        ApplyInputs();
        body.linearVelocity = transform.forward * currentSpeed;

    }

    public void Freeze()
    {

    }
}
