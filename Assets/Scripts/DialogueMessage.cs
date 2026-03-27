using UnityEngine;
using System;
using System.Collections.Generic;

public class DialogueMessage : MonoBehaviour
{
    public string text;
    public Action callback;
    public Func<Terminal, bool> requirement;
    public DialogueMessage next;
    public DialogueOption[] options;
    public Terminal t;

    public bool CheckRequirement()
    {
        if (requirement == null) return true;
        return requirement(t.GetComponent<Terminal>());
    }
}
