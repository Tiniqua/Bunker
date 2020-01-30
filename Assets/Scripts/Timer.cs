using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerLabel;

    public static float time;

    void Update()
    {
        time += Time.deltaTime;

        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60;//Use the euclidean division for the seconds.

        //update the label value
        timerLabel.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        
    }
}
