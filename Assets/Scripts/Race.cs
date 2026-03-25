using UnityEngine;

public class Race : MonoBehaviour
{

    void Start(){
        Transform prev = null;
        foreach(Transform t in transform)
        {
            if(prev != null){
                prev.gameObject.GetComponent<Hoop>().next = t.gameObject;
            }
            t.gameObject.SetActive(false);
            prev = t;
        }
        if(transform.childCount>0)transform.GetChild(0).gameObject.SetActive(true);
    }

}
