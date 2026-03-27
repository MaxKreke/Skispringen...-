using UnityEngine;
using TMPro;
using UnityEngine.UI; // Wichtig für die Item-Bilder!

public class TransitionManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI trustText;
    
    [Header("Goal Panel Settings")]
    public GameObject goalPanel;
    public TextMeshProUGUI goalDescription;

    [Header("Inventory Settings")] // Diese Felder haben dir gefehlt!
    public GameObject itemSlotPrefab; 
    public Transform inventoryContainer; 

    private string[] charNames = { "Nobody", "Jimmy", "Robert", "John", "John", "Pete" };

    void Start()
    {
        Terminal terminal = Object.FindAnyObjectByType<Terminal>();
        
        if (terminal != null)
        {
            goalPanel.SetActive(true);

            // Hier prüfen wir auf Max' Logik: Start oder nach Dialog
            // Falls er den Bool im Repo "isFirstStart" genannt hat, hier anpassen:
            if (terminal.location == 0) 
            {
                int targetID = terminal.characterAtLocation[0]; 
                goalDescription.text = "NEUER RUN GESTARTET\n\nZiel: Freundschaft mit " + charNames[targetID];
                ClearInventoryUI();
            }
            else 
            {
                int lastCharID = terminal.GetCharacter();
                int trust = GetValue(terminal, "character_trust_" + lastCharID);
                
                goalDescription.text = "MISSION UPDATE\n\n" + charNames[lastCharID] + " Vertrauen: " + trust + "%";
                UpdateInventoryUI(terminal); // Hier werden die Bilder geladen
            }
        }
        UpdateUI();
    }

    void UpdateInventoryUI(Terminal terminal)
    {
        ClearInventoryUI();
        foreach (var itemData in terminal.inventory)
        {
            GameObject newSlot = Instantiate(itemSlotPrefab, inventoryContainer);
            // Achte auf das Leerzeichen zwischen Item und Icon/Name!
            newSlot.transform.Find("Item Icon").GetComponent<RawImage>().texture = itemData.itemImage;
            newSlot.transform.Find("Item Name").GetComponent<TextMeshProUGUI>().text = itemData.itemName;
        }
    }

    void ClearInventoryUI()
    {
        if (inventoryContainer == null) return;
        foreach (Transform child in inventoryContainer) Destroy(child.gameObject);
    }

    public void CloseGoalPanel() { goalPanel.SetActive(false); }

    public void UpdateUI()
    {
        Terminal terminal = Object.FindAnyObjectByType<Terminal>();
        if (terminal != null)
        {
            moneyText.text = "Money: $" + GetValue(terminal, "Money");
            int currentCharID = terminal.GetCharacter();
            trustText.text = "Trust: " + GetValue(terminal, "character_trust_" + currentCharID);
        }
    }

    private int GetValue(Terminal terminal, string keyName)
    {
        if (terminal.integerFlags == null) return 0;
        foreach (var flag in terminal.integerFlags)
        {
            if (flag.key == keyName) return flag.value;
        }
        return 0;
    }
}