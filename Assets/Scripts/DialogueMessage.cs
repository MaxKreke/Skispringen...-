using UnityEngine;
using System;
using System.Collections.Generic;

public class DialogueMessage : Dialogue
{
    public string text;
    public Action callback;
    public Func<Terminal, bool> requirement;
    public Terminal t;

    public bool CheckRequirement()
    {
        if (requirement == null) return true;
        return requirement(t.GetComponent<Terminal>());
    }

    public override bool HasNext()
    {
        return (next != null);
    }

    public override string GetText()
    {
        return text;
    }

    public override void Next(TextManager tm)
    {
        if (this.transform.childCount > 0)
        {
            PassOptions(tm);
            return;
        }
        EndScene();
    }
}
