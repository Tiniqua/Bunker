using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class died : MonoBehaviour
{
   public void quitgame()

    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
