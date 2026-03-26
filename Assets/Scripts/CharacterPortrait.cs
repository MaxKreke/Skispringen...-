using UnityEngine;
using UnityEngine.UI;

public class CharacterPortrait : MonoBehaviour
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
            int location = t.location;

            if (location > 0)
            {
                int character = t.GetCharacter();
                if (character > 0)
                {
                    this.GetComponent<RawImage>().texture = tex[character-1];
                }
            }
        }
    }
}
