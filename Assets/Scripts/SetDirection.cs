using UnityEngine;

public class SetDirection : MonoBehaviour
{
    private Transform o;
    private Transform u;
    private Transform l;
    private Transform r;
    private Transform[] arroz;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        o = transform.GetChild(0);
        u = transform.GetChild(1);
        l = transform.GetChild(2);
        r = transform.GetChild(3);
        arroz = new Transform[] { o, u, l, r };
    }

    public void Front()
    {
        foreach (Transform t in arroz) t.gameObject.SetActive(false);
    }

    public void Back()
    {
        foreach (Transform t in arroz) t.gameObject.SetActive(true);
    }

    public void Left()
    {
        Front();
        l.gameObject.SetActive(true);
    }

    public void Right()
    {
        Front();
        r.gameObject.SetActive(true);
    }

    public void Up()
    {
        Front();
        o.gameObject.SetActive(true);
    }

    public void Down()
    {
        Front();
        u.gameObject.SetActive(true);
    }

}
