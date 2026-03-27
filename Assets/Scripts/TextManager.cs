using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public Terminal t;
    public DialogueCatalogue dc;
    public TextMeshProUGUI text;
    public TextMeshProUGUI charName;
    public DialogueMessage current;

    public string[] nameList =
    {
        " ",
        "Jimmy",
        "Robert",
        "John",
        "Other John",
        "Pete"
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject terminal = GameObject.Find("Terminal");
        if (terminal == null) return;
        t = terminal.GetComponent<Terminal>();
        int location = t.location;
        charName.text = nameList[t.GetCharacter()];
        if (location <= 0) return;
        current = dc.transform.GetChild(location-1).GetChild(0).GetComponent<DialogueMessage>();
        SetText();
    }

    private void SetText()
    {
        if (current == null) return;
        text.text = current.text;
    }

    public void Next()
    {
        Debug.Log("NEXT");
        if(current.next == null)
        {
            SceneManager.LoadScene(1);
        }
    }

}
