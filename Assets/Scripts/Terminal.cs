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
    public int life = 3;

    //0 = Home
    //1 = Bakery
    //2 = Octopus Garden
    //3 = Bird Park
    //4 = Shangri La
    //5 = The Staircase
    public int location = 0;


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
