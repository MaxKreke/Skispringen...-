using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DynamicOptionsMenu : MonoBehaviour
{
    public GameObject buttonPrefab;
    public TextManager tm;

    public void CreateButtons(DialogueOption[] data)
    {
        Terminal t = GameObject.Find("Terminal").GetComponent<Terminal>();
        for (int i = 0; i < data.Length; i++)
        {
            DialogueOption option = data[i];

            GameObject btnObj = Instantiate(buttonPrefab, this.transform);
            RectTransform rt = btnObj.GetComponent<RectTransform>();

            // Move each button down by 70 * index
            rt.anchoredPosition = new Vector2(0, -(i+1)*40);

            // Set text (TMP version)
            TextMeshProUGUI text = btnObj.GetComponentInChildren<TextMeshProUGUI>();
            text.text = data[i].text;

            // Add click listener
            Button btn = btnObj.GetComponent<Button>();

            btn.interactable = option.CheckRequirement(t);

            btn.onClick.AddListener(() => OnButtonClicked(option));
        }
    }

    void OnButtonClicked(DialogueOption option)
    {
        if (option.next == null)
        {
            SceneManager.LoadScene(4);
            return;
        }
        else
        {
            tm.current = option.next;
            tm.SetText();
            tm.TrySetCharacter();
        }
        ClearButtons();
    }

    void ClearButtons()
    {
        foreach(Transform t in this.transform)
        {
            GameObject.Destroy(t.gameObject);
        }
        this.gameObject.SetActive(false);
    }
}
