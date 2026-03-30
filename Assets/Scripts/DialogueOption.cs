using UnityEngine;
using System;
using System.Collections.Generic;

public class DialogueOption : MonoBehaviour
{
    public string text;
    public Action callback;
    public int statRequirement = -1;
    public int flagRequirement = -1;
    public int statRequirementLevel = 5;
    public Dialogue next;

    public bool CheckRequirement(Terminal t)
    {
        if (statRequirement >= 0)
        {
            if (flagRequirement >= 0) return (t.boolFlags[flagRequirement].value && t.integerFlags[statRequirement].value > statRequirementLevel);
            return (t.integerFlags[statRequirement].value > statRequirementLevel);
        } else if (flagRequirement >= 0) return (t.boolFlags[flagRequirement].value);
        
        //Commenting just to check if unities' compiler works now

        return true;

    }
}
