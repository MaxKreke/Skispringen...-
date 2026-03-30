using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IntegerFlag
{
    public string key;
    public int value;
}

[Serializable]
public class BooleanFlag
{
    public string key;
    public bool value;
}

[Serializable]
public class DialogueSubScene
{
    public string title;
    public string id;
    public int location;
    //public bool needAllRequirements;
    public int[] necessaryBoolFlags;
    public int[] necessaryIntFlags;
    public int[] antiBoolFlags;
}

public class Terminal : MonoBehaviour
{

    public List<IntegerFlag> integerFlags;
    public List<BooleanFlag> boolFlags;
    public List<DialogueSubScene> subScenes;
    public int tutorialStage;
    public float speedRunTime;
    public int ending = -1;

    //0 = Studio
    //1 = Bakery
    //2 = Octopus Garden
    //3 = Bird Park
    //4 = Shangri La
    //5 = The Staircase
    public int location = 0;
    public int targetLocation = -1;
    //CharacterID:
    //0 = Nobody(empty)
    //1 = Paige
    //2 = Robbie
    //3 = Bonzo
    //4 = JP
    //5 = Pete
    public int[] characterAtLocation =
    {
        2,2,2,2,2,2
    };

    public string GetCurrentSubScene()
    {
        List<DialogueSubScene> subscenelist = GetSubScenesThatMeetRequirements();
        DialogueSubScene subScene = subscenelist[location];
        return subScene.id;
    }

    public List<DialogueSubScene> GetSubScenesThatMeetRequirements()
    {
        List<DialogueSubScene> returnList = new List<DialogueSubScene>();
        for (int i = 0; i < 6; i++)
        {
            returnList.Add(null);
        }
        bool[] occupied = {
            false, false, false, false, false, false
        };

        foreach (DialogueSubScene dss in subScenes) {
            int dssLocation = dss.location;
            if (occupied[dssLocation]) continue;
            bool checksOut = ChecksOut(dss);

            if (!checksOut) continue;

            returnList[dssLocation] = dss;
            occupied[dssLocation] = true;
        }

        return returnList;
    }

    public List<DialogueSubScene> GetReducedSubScenesThatMeetRequirements()
    {
        List<DialogueSubScene> returnList = GetSubScenesThatMeetRequirements();
        returnList.RemoveAll(dss => dss == null);
        return returnList;
    }

    public bool ChecksOut(DialogueSubScene dss)
    {

        if(dss.title == "Reunite the band")
        {
            bool OK = true;
            if (!boolFlags[1].value) return false;
            if (!boolFlags[16].value) return false;
            if (!boolFlags[14].value) return false;
            if (!boolFlags[3].value) return false;

            return true;
        }


        foreach(int i in dss.antiBoolFlags)
        {
            if (boolFlags[i].value)return false;
        }

        bool boolFlagsBool = (dss.necessaryBoolFlags.Length == 0);
        bool intFlagsBool = (dss.necessaryIntFlags.Length == 0);

        foreach(int i in dss.necessaryBoolFlags)
        {
            if (boolFlags[i].value) boolFlagsBool = true;
        }

        foreach(int i in dss.necessaryIntFlags)
        {
            if(integerFlags[i].value >= 6) intFlagsBool = true;
        }

        return (boolFlagsBool && intFlagsBool);
    }

    public int GetCharacter()
    {
        if (location <= 0) return 0;
        return characterAtLocation[location-1];
    }

    public bool CheckFlag(string key)
    {
        for (int i = 0; i < boolFlags.Count; i++)
        {
            if (boolFlags[i].key == key)
            {
                return boolFlags[i].value;
            }
        }

        // default if flag doesn't exist
        return false;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
