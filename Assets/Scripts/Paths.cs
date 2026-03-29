using UnityEngine;

public class Paths : MonoBehaviour
{

    Terminal t;
    Fly f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = GameObject.Find("Terminal").GetComponent<Terminal>();
        f = GameObject.Find("Zeppelin").GetComponent<Fly>();

        int location = t.location;
        int targetLocation = t.targetLocation;
        bool forward = (location < targetLocation);

        string pathName = forward ? location.ToString()+"-"+targetLocation.ToString() : targetLocation.ToString() + "-" + location.ToString();

        foreach (Transform tf in this.transform)
        {
            tf.gameObject.SetActive(false);
            if(tf.gameObject.name == pathName)
            {
                tf.gameObject.SetActive(true);
                f.target = tf.gameObject.GetComponent<Race>().Initialize(forward);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetActiveRace()
    {
        return this.transform;
    }
}
