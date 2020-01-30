using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickr : MonoBehaviour
{
    Light flickerLight;
    private float min = .3f;
    private float max = .9f;
    private float minBright = .7f;
    private float maxBright = 1.1f;

    private void Start()
    {
        flickerLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(min,max));
            flickerLight.intensity = Random.Range(minBright, maxBright);
        }
    }

}
