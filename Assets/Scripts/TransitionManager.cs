using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class TransitionManager : MonoBehaviour
{
    [Header("Terminal Connection")]
    public Terminal terminal;

    [Header("UI Stats Panel (New Social Flags)")]
    public TextMeshProUGUI passionText;
    public TextMeshProUGUI coolText;
    public TextMeshProUGUI drugsText;
    public TextMeshProUGUI guitarText;

    [Header("Goal Panel (Mission Update)")]
    public GameObject goalPanel;
    public TextMeshProUGUI goalDescription;

    [Header("Map Buttons")]
    public List<MapButton> allMapButtons; 

    private string[] charNames = { " ", "Paige", "Robbie", "Bonzo", "JP", "Pete" };

    void Start()
    {
        // Terminal suchen, falls nicht im Inspector zugewiesen
        if (terminal == null) terminal = Object.FindAnyObjectByType<Terminal>();

        if (terminal != null)
        {
            goalPanel.SetActive(true);
            SetupGoalDescription();
            RefreshMapUI();
        }
    }

    // Kombiniert: Alte Missions-Logik + Neue Stats/Buttons
    public void RefreshMapUI()
    {
        UpdateSocialStats();
        UpdateDynamicButtons();
    }

    private void SetupGoalDescription()
    {
        string storyLog = "<b>CITY RECORD:</b>\n\n";
        bool anyEvent = false;

        // Teamwork vs Selfishness
        if (GetBoolFlag("EncouragedTeamwork")) { storyLog += "• Unity is growing.\n"; anyEvent = true; }
        if (GetBoolFlag("EncouragedSelfishness")) { storyLog += "• Discord is spreading.\n"; anyEvent = true; }
        if (GetBoolFlag("SuggestedSoloCareer")) { storyLog += "• A solo path was chosen.\n"; anyEvent = true; }

        // Pete's Path
        if (GetBoolFlag("SoberPete")) { storyLog += "• Pete remains sober.\n"; anyEvent = true; }
        if (GetBoolFlag("EncourageAlcoholism")) { storyLog += "• Pete has relapsed.\n"; anyEvent = true; }
        if (GetBoolFlag("EncourageModeration")) { storyLog += "• Pete is finding balance.\n"; anyEvent = true; }

        // The Deal
        if (GetBoolFlag("ArrangeDrugDeal")) { storyLog += "• The deal is in motion.\n"; anyEvent = true; }
        if (GetBoolFlag("GaveHeroin")) { storyLog += "• The deal turned dark.\n"; anyEvent = true; }
        if (GetBoolFlag("GaveSugar")) { storyLog += "• You pulled a prank.\n"; anyEvent = true; }

        // Robbie's Guitar
        if (GetBoolFlag("ReturnedGuitar")) { storyLog += "• The guitar is home.\n"; anyEvent = true; }
        else if (GetBoolFlag("GotGuitar")) { storyLog += "• You hold the guitar.\n"; anyEvent = true; }

        // Personal
        if (GetBoolFlag("LearnMeditation")) { storyLog += "• You found inner peace.\n"; anyEvent = true; }

        if (!anyEvent) {
            storyLog += "The streets are quiet. Your choices will write the story.";
        }

        goalDescription.text = storyLog;
    }

    private void UpdateSocialStats()
    {
        if (terminal == null) return;

        // Wir prüfen erst, ob die Felder überhaupt zugewiesen sind
        if (passionText != null) passionText.text = "Passion: " + GetFlagValue("Passion");
        if (coolText != null) coolText.text = "Cool: " + GetFlagValue("Cool");
        if (drugsText != null) drugsText.text = "Drugs: " + GetFlagValue("Drugs");
        if (guitarText != null) guitarText.text = "Guitar: " + GetFlagValue("Guitar");
    }

    private void UpdateDynamicButtons()
    {
        var allowedScenes = terminal.GetSubScenesThatMeetRequirements();

        foreach (MapButton mapBtn in allMapButtons)
        {
            DialogueSubScene foundScene = allowedScenes.Find(s => s.location == mapBtn.targetIndex);
            Button btnComp = mapBtn.GetComponent<Button>();

            if (foundScene != null)
            {
                if (btnComp != null) btnComp.interactable = true;
                if (mapBtn.titleText != null) mapBtn.titleText.text = foundScene.title;
            }
            else
            {
                if (btnComp != null) btnComp.interactable = false;
                if (mapBtn.titleText != null) mapBtn.titleText.text = "";
            }
        }
    }

    private int GetFlagValue(string keyName)
    {
        var flag = terminal.integerFlags.Find(f => f.key == keyName);
        return flag != null ? flag.value-1 : 0;
    }

    public void CloseGoalPanel() { goalPanel.SetActive(false); }

    private bool GetBoolFlag(string keyName)
{
    if (terminal == null || terminal.boolFlags == null) return false;
    var flag = terminal.boolFlags.Find(f => f.key == keyName);
    return flag != null ? flag.value : false;
}
}
