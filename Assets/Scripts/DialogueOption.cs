using UnityEngine;
using System;
using System.Collections.Generic;

public class DialogueOption : MonoBehaviour
{
    public string text;
    public Action callback;
    public int statRequirement = -1;
    public int flagRequirement = -1;
    public int flagRequirementLevel = 5;
    public Dialogue next;

    public bool CheckRequirement(Terminal t)
    {
        if (statRequirement >= 0) return (t.integerFlags[statRequirement].value > flagRequirementLevel);
        if (flagRequirement >= 0) return (t.boolFlags[flagRequirement].value);
        return true;
    }
}
