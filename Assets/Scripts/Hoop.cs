using UnityEngine;

public class Hoop : MonoBehaviour
{
    public GameObject zeppelin;
    public GameObject next;

    public void Start()
    {
        zeppelin = GameObject.Find("Zeppelin");
        Vector3 other = zeppelin.transform.position;
        Vector3 direction = (other - transform.position);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.Rotate(90 * Vector3.right);
    }

    void OnEnable()
    {
        Start();
    }

    void Update()
    {

    }

    public void Trigger()
    {
        if (next != null) next.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
