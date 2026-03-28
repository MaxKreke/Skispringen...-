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
public class Item
{
    public string itemName;
    public Texture itemImage;
}

[Serializable]
public class DialogueSubScene
{
    public string title;
    public string id;
    public int location;
    public bool needAllRequirements;
    public int[] necessaryBoolFlags;
    public int[] necessaryIntFlags;
}

public class Terminal : MonoBehaviour
{

    public List<IntegerFlag> integerFlags;
    public List<BooleanFlag> boolFlags;
    public List<Item> inventory;
    public List<DialogueSubScene> subScenes;
    public int tutorialStage;
    public float speedRunTime;

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
        2,2,2,2,2
    };

    public List<DialogueSubScene> GetSubScenesThatMeetRequirements()
    {
        List<DialogueSubScene> returnList = new List<DialogueSubScene>();
        foreach (DialogueSubScene dss in subScenes) {
            bool checksOut = true;

            //TO DO!!!
            //Run all checks

            if(checksOut)returnList.Add(dss);
        }

        return returnList;
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
