using UnityEngine;
using TMPro;

public class CreditsTimer : MonoBehaviour
{

    public TextMeshProUGUI text;

    private string[] endings =
    {
        "Rob Solo Career",
        "Ascension with Paul",
        "Reunion",
        "Super Group Pete and Paige",
        "Octopus garden drug den",
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Terminal t = GameObject.Find("Terminal").GetComponent<Terminal>();
        if (t != null)
        {
            float srt = t.speedRunTime;
            var timetime = System.TimeSpan.FromSeconds(t.speedRunTime);
            string timeString = timetime.ToString(@"hh\:mm\:ss");
            string endingString = endings[t.ending];

            text.text = "Time: "+ timeString + "\nEnding: " + endingString;
        }
    }
}
