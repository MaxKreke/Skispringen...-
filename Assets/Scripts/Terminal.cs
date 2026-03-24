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
