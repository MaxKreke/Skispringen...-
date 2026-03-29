using UnityEngine;
using UnityEngine.SceneManagement;


public class Dialogue : MonoBehaviour
{

    public Dialogue next;  

    public virtual bool HasNext()
    {
        return true;
    }

    public virtual string GetText()
    {
        return "DEBUG";
    }

    public virtual void Next(TextManager tm)
    {
        return;
    }

    protected void EndScene()
    {
        SceneManager.LoadScene(4);
    }

    protected void EndGame()
    {
        SceneManager.LoadScene(5);
    }

    protected void PassOptions(TextManager tm)
    {
        DialogueOption[] options = GetComponentsInChildren<DialogueOption>();
        Debug.Log("PASSING OPTIONS...");
        Debug.Log(options);
        tm.ShowOptions(options);
    }

    public virtual int TryGetCharacter()
    {
        return -1;
    }

}
