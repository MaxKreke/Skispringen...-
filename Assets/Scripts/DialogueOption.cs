using UnityEngine;
using System;
using System.Collections.Generic;

public class DialogueOption : MonoBehaviour
{
    public string text;
    public Action callback;
    public Func<Terminal, bool> requirement;
    public DialogueMessage next;

    public bool CheckRequirement()
    {
        if (requirement == null) return true;
        GameObject t = GameObject.Find("Terminal");
        if (t == null) return false;
        return requirement(t.GetComponent<Terminal>());
    }
}
