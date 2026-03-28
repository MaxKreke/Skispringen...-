using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Sentence
{
    //CharacterID:
    //0 = Nobody(empty)
    //1 = Paige
    //2 = Robbie
    //3 = Bonzo
    //4 = JP
    //5 = Pete
    //6 = You
    public int character;
    public string words;
}

public class MulticharacterDialogue : Dialogue
{
    public Sentence[] dialogueContent;
    public int state = 0;

    public override bool HasNext()
    {
        if (state < dialogueContent.Length-1) return true;
        if (this.transform.childCount > 0) return true;
        if (next != null) return true; 
        return false;
    }

    public override string GetText()
    {
        return dialogueContent[state].words;
    }

    public override void Next(TextManager tm)
    {
        if(state < dialogueContent.Length - 1)
        {
            state++;
            tm.SetText();
            tm.SetCharPort(dialogueContent[state].character);
            tm.SetCharName(dialogueContent[state].character);
            return;
        }
        if (this.transform.childCount > 0)
        {
            PassOptions(tm);
            return;
        }
        EndScene();
    }

    public override int TryGetCharacter()
    {
        return dialogueContent[state].character;
    }

}
