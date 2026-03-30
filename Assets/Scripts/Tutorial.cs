using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Fly fly;
    public TextMeshProUGUI tutorialText;
    public Terminal t;
    public Transform tutorialRing;
    public Hoop tutRingScript;
    public GameObject haus;

    private void Start()
    {
        if(!t)t = GameObject.Find("Terminal").GetComponent<Terminal>();
    }

    public void Next()
    {
        switch (t.tutorialStage)
        {
            case 0:
                tutorialText.text = "Use W/U/Up-Arrow to steer down.\nUse S/J/Down-Arrow to steer up.";
                tutorialRing.transform.position += new Vector3(0,-100,600);
                tutRingScript.Start();
                break;
            case 1:
                tutorialRing.transform.position += new Vector3(0, -250, 500);
                tutRingScript.Start();
                break;
            case 2:
                tutorialText.text = "Use A/H/Left-Arrow to roll left.\nUse D/K/Right-Arrow to roll right.";
                tutorialRing.transform.position += new Vector3(500, -250, 500);
                tutRingScript.Start();
                break;
            case 3:
                tutorialText.text = "Well done! Now fly to your Studio";
                tutorialRing.gameObject.SetActive(false);
                haus.SetActive(true);
                fly.target = haus.transform;
                break;
            case 4:
                t.tutorialStage++;
                SceneManager.LoadScene(3);
                break;
            default: 
                break;
        }
        t.tutorialStage++;
    }
}
