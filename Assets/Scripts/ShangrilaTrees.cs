using UnityEngine;

public class ShangrilaTrees : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(Transform t in this.transform)
        {
            t.rotation = Quaternion.Euler(ClampGaussian(0f, 2f, 6f)-90f,
            Random.Range(0f, 360f),                     
            ClampGaussian(0f, 2f, 6f));
        }
    }


    // Generates a Gaussian value and clamps it
    float ClampGaussian(float mean, float stdDev, float clamp)
    {
        float value = GaussianRandom(mean, stdDev);
        return Mathf.Clamp(value, -clamp, clamp);
    }

    // Box-Muller transform to get Gaussian distributed random number
    float GaussianRandom(float mean, float stdDev)
    {
        float u1 = 1.0f - Random.value; // Uniform(0,1] random floats
        float u2 = 1.0f - Random.value;
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) *
                              Mathf.Sin(2.0f * Mathf.PI * u2); // Standard Normal (0,1)
        return mean + stdDev * randStdNormal;
    }

}
