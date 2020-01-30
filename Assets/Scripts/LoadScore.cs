using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class LoadScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highscoreLabel;

    void Awake()
    {
        LoadFile();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.txt";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenRead(destination);
            highscoreLabel.text = "High Score: " + file;
        }
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        bf.Deserialize(file);
        file.Close();
        print("Loaded score");
    }
}
