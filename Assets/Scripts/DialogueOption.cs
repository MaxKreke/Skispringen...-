using UnityEngine;
using System;

public class DialogueOption : MonoBehaviour
{
    public string text;
    public Action callback;
    public Action requirement;
    public DialogueMessage next;
}
