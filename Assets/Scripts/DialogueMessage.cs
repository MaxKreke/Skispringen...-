using UnityEngine;
using System;

public class DialogueMessage : MonoBehaviour
{
    public string text;
    public Action callback;
    public Action requirement;
    public DialogueMessage next;
    public DialogueOption[] options;
}
