using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{

    public Texture[] tex;
    private Terminal t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = null;
        GameObject terminal = GameObject.Find("Terminal");
        if (terminal)
        {
            t = terminal.GetComponent<Terminal>();
            this.GetComponent<RawImage>().texture = tex[t.location];
        }
    }

}
