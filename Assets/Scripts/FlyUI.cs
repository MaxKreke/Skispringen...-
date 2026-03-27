using UnityEngine;
using TMPro;


public class FlyUI : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI height;

    public Transform player;
    public Rigidbody body;
    public Terminal t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = GameObject.Find("Terminal").GetComponent<Terminal>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t.speedRunTime += 1;
        var timetime = System.TimeSpan.FromSeconds(t.speedRunTime);
        time.text = "Time: " + timetime.ToString(@"hh\:mm\:ss");
    }

    void Update()
    {
        speed.text = "Speed: " + body.linearVelocity.magnitude + "m/s";
        height.text = "Height: " + player.position.y + "m";

    }

}
