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
    public int value;
}

[Serializable]
public class Item
{
    public string itemName;
    public Texture itemImage;
}

public class Terminal : MonoBehaviour
{

    public List<IntegerFlag> integerFlags;
    public List<BooleanFlag> boolFlags;
    public List<Item> inventory;
    public int tutorialStage;
    public float speedRunTime;

    //0 = Home
    //1 = Bakery
    //2 = Octopus Garden
    //3 = Bird Park
    //4 = Shangri La
    //5 = The Staircase
    public int location = 0;

    //CharacterID:
    //0 = Nobody(empty)
    //1 = Jimmy
    //2 = Robert
    //3 = John
    //4 = Also John
    //5 = Pete
    public int[] characterAtLocation =
    {
        2,2,2,2,2
    };

    public int GetCharacter()
    {
        if (location <= 0) return 0;
        return characterAtLocation[location-1];
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
