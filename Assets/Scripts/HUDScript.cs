using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
  
    public GameObject MessagePanel;

    // Start is called before the first frame update
    void Start()
    {
       
    }


    public void OpenMessagePanel (string text)
    {
        MessagePanel.SetActive(true); 

        //TODO : Set text when we will use this for other messages
    }

    public void CloseMessagePanel()
    {

        MessagePanel.SetActive(false);

    }
}
