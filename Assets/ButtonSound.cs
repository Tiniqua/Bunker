using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{

    public AudioSource myFX;
    public AudioClip hoverFX;
    

    public void HoverSound()
    {
        myFX.PlayOneShot(hoverFX);
    }
}
