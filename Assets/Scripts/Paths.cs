using UnityEngine;

public class Paths : MonoBehaviour
{

    Terminal t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = GameObject.Find("Terminal").GetComponent<Terminal>();        
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
