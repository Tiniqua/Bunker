using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class KillsManager : MonoBehaviour
{
    public static int score;        // The player's score.

    TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        score = 0;
    }

    void Update()
    {
        text.text = "Enemies Killed : " + score;
    }
}