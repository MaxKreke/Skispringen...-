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
    public int setsFlag = -1;
    public int gainsStat = -1;
    public int isEnding = -1;

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

        //Set Flags
        Terminal t = GameObject.Find("Terminal").GetComponent<Terminal>();
        if (gainsStat >= 0)
        {
            t.integerFlags[gainsStat].value++;
            string statName = t.integerFlags[gainsStat].key;

            
            tm.SetText(statName + " increased by 1.");
            tm.SetCharPort(0);
            tm.SetCharName(0);

            gainsStat = -1;
            return;
        }
        if (setsFlag >= 0)
        {
            t.boolFlags[setsFlag].value = true;
            setsFlag = -1;
            EndScene();
            return;
        }
        if(isEnding >= 0){
            t.ending = isEnding;
            EndGame();
            return;
        }
        EndScene();
    }

    public override int TryGetCharacter()
    {
        return dialogueContent[state].character;
    }

}
