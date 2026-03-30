using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orbit : MonoBehaviour
{

    public Vector3 pivot;
    public float radius;
    public float height;
    private float frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frames+=0.004f;
        transform.position = pivot + radius*Vector3.left * Mathf.Sin(frames)+radius*Vector3.forward * Mathf.Cos(frames)+Vector3.up*height;
        transform.LookAt(pivot);
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
    }
}
