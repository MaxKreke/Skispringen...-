using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    // Die Nummer des Ziels (0 = Shangri La, etc.)
    public int targetIndex;

    public void OnClick()
    {
        // 1. Terminal finden
        Terminal terminal = Object.FindAnyObjectByType<Terminal>();
        
        if (terminal != null)
        {
            // 2. Ziel im Terminal setzen (Variable heißt 'Location')
            terminal.location = targetIndex;
            Debug.Log("Ziel auf " + targetIndex + " gesetzt.");
            
            // 3. Die Flug-Szene laden
            SceneManager.LoadScene("FlyScene");
        }
    }
}