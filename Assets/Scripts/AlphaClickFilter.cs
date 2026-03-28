using UnityEngine;
using UnityEngine.UI;

public class AlphaClickFilter : MonoBehaviour
{
    void Start()
    {
        // Holt sich die Image-Komponente des Buttons
        Image img = GetComponent<Image>();
        
        if (img != null)
        {
            // 0.1f bedeutet: Alles, was weniger als 10% Deckkraft hat, 
            // wird beim Klicken ignoriert.
            img.alphaHitTestMinimumThreshold = 0.1f;
        }
    }
}