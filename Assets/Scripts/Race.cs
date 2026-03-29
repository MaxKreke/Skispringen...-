using UnityEngine;

public class Race : MonoBehaviour
{
    public Transform Initialize(bool forward){
        Transform first = null;
        Transform prev = null;

        int start = forward ? 0 : transform.childCount-1;
        int end = forward ? transform.childCount : 0;
        int step = forward ? 1 : -1;

        for (int i = start; forward? i<end:i>=end ; i+=step)
        {
            Transform t = transform.GetChild(i);

            if (first == null) first = t;

            if(prev != null){
                prev.gameObject.GetComponent<Hoop>().next = t.gameObject;
            }
            t.gameObject.SetActive(false);
            prev = t;
        }

        first.gameObject.SetActive(true);
        return first;
    }

}
