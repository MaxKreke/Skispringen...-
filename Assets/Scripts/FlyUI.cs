using UnityEngine;
using TMPro;


public class FlyUI : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI height;
    public TextMeshProUGUI life;
    public Transform player;
    public Rigidbody body;
    public Terminal t;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
        t = GameObject.Find("Terminal").GetComponent<Terminal>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += 1;
        var t = System.TimeSpan.FromSeconds(timer);
        time.text = "Time: " + t.ToString(@"hh\:mm\:ss");
    }

    void Update()
    {
        speed.text = "Speed: " + body.linearVelocity.magnitude + "m/s";
        height.text = "Height: " + player.position.y + "m";
        life.text = "LIFE: " + t.life;

    }

}
