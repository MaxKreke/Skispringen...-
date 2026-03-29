using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public Terminal t;
    public DialogueCatalogue dc;
    public TextMeshProUGUI text;
    public TextMeshProUGUI charName;
    public Dialogue current;
    public CharacterPortrait charPort;
    public DynamicOptionsMenu dom;

    //0 = Nobody(empty)
    //1 = Paige
    //2 = Robbie
    //3 = Bonzo
    //4 = JP
    //5 = Pete
    //6 = You
    private string[] nameList =
    {
        " ",
        "Paige",
        "Robbie",
        "Bonzo",
        "JP",
        "Pete",
        "You",
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject terminal = GameObject.Find("Terminal");
        if (terminal == null) return;

        Debug.Log("Got Terminal.");

        t = terminal.GetComponent<Terminal>();
        int location = t.location;
        SetCharName(t.GetCharacter());

        Debug.Log(location);

        if (location < 0) return;

        Debug.Log("Here");
        Debug.Log(dc.transform.GetChild(location).GetChild(0));
        current = dc.transform.GetChild(location).GetChild(0).GetComponent<Dialogue>();
        Debug.Log(current);

        SetText();
    }

    public void SetText()
    {
        if (current == null) return;
        text.text = current.GetText();
    }

    public void SetText(string customText)
    {
        text.text = customText;
    }

    public void TrySetCharacter()
    {
        int character = current.TryGetCharacter();
        if (character == -1) return;
        SetCharPort(character);
        SetCharName(character);
    }

    public void SetCharPort(int idx)
    {
        charPort.Set(idx);
    }

    public void SetCharName(int idx)
    {
        charName.text = nameList[idx];
    }

    public void Next()
    {
        current.Next(this);
    }

    public void ShowOptions(DialogueOption[] data)
    {
        dom.gameObject.SetActive(true);
        dom.CreateButtons(data);
    }
}
