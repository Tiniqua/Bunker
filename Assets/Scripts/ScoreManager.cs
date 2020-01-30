using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreLabel;
    private float time;
    public static int score;
    public static int finalScore;
    public GameObject Boss;
    public bool wonGame;
    public TMP_Text finalScoreText;

    void Awake()
    {
        score = 0;
    }

    void Update()
    {

        wonGame = Boss.GetComponent<BigBoss>().BossDied;

        if (!wonGame)
        {
            time += Time.deltaTime;
            var seconds = time % 60;
            scoreLabel.text = "Score : " + (score * seconds).ToString("F0");

        }
        else if (wonGame)
        {   
            scoreLabel.text = "Score : " + finalScore;
            finalScoreText.text = "YOUR FINAL SCORE IS : " + finalScore.ToString("F0");
        }
    }

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.txt";
        FileStream file;

        if (File.Exists(destination))
            file = File.OpenWrite(destination);
        else
            file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, score);
        print("Saved score");
        file.Close();
    }
}