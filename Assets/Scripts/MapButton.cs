using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MapButton : MonoBehaviour
{
    // Die Nummer des Ziels (0 = Shangri La, etc.)
    public int targetIndex;
    public TextMeshProUGUI titleText;
    public void OnClick()
    {
        // 1. Terminal finden
        Terminal terminal = Object.FindAnyObjectByType<Terminal>();
        
        if (terminal != null)
        {
            // 2. Ziel im Terminal setzen (Variable heißt 'Location')
            terminal.targetLocation = targetIndex;
            Debug.Log("Ziel auf " + targetIndex + " gesetzt.");


            if (terminal.targetLocation != terminal.location)
            {
                // 3. Die Flug-Szene laden wenn man nicht schon vor ort ist
                SceneManager.LoadScene("FlyScene");
            } else
            {
                //3b. Sonst Lade die dialogscene
                SceneManager.LoadScene("DialogueScene");
            }
        }
    }
}