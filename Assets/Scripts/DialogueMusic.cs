using UnityEngine;
using System.Collections;

public class DialogueMusic : MonoBehaviour
{
    public AudioClip[] clips;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Terminal terminal = Object.FindAnyObjectByType<Terminal>();
        if (terminal == null) return;
        AudioSource auS = GetComponent<AudioSource>();
        auS.clip = clips[terminal.location];
        auS.Play();
    }
}
