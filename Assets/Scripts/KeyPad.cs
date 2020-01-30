using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyPad : MonoBehaviour
{
    public string currentPasscode = "12345";
    public string input;
    public bool onTrigger;
    public bool doorOpened;
    public bool keypadScreen;
    public bool passcodeCorrect;
    public bool retry;
    private GameObject player;
    public GameObject door;
    public GameObject keyPadMessage;
    public GameObject keyPad;
    public TMP_Text inputText;
   


    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onTrigger = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onTrigger = false;
            keypadScreen = false;
            keyPadMessage.SetActive(false);
            input = "";
        }

    }

    void Update()
    {
        if (passcodeCorrect)
        {
            Destroy(door);
            doorOpened = true;
            keyPadMessage.SetActive(false);
            Time.timeScale = 1f;
        }
        else if(!passcodeCorrect && retry)
        {
            inputText.text = "ERROR TRY AGAIN: " + input;
            
        }
    }

    void OnGUI()
    {
        if(onTrigger)
        {
            keyPadMessage.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            {
                keypadScreen = true;
                onTrigger = false;
                Time.timeScale = 0f;
            }
            
        }

        if(keypadScreen)
        {
            keyPad.SetActive(true);
            inputText.text = "CODE: " + input;
        }
    }

    public void PressButton1()
    {
        input = input + "1";
    }
    public void PressButton2()
    {
        input = input + "2";
    }
    public void PressButton3()
    {
        input = input + "3";
    }
    public void PressButton4()
    {
        input = input + "4";
    }
    public void PressButton5()
    {
        input = input + "5";
    }
    public void PressButton6()
    {
        input = input + "6";
    }
    public void PressButton7()
    {
        input = input + "7";
    }
    public void PressButton8()
    {
        input = input + "8";
    }
    public void PressButton9()
    {
        input = input + "9";
    }
    public void PressButton0()
    {
        input = input + "0";
    }
    public void PressButtonEnter()
    {
        if(input == currentPasscode)
        {
            passcodeCorrect = true;
        }
        else
        {
            passcodeCorrect = false;
            input = "";
            retry = true;
           
        }
    }
    public void PressButtonExit()
    {
        if(doorOpened)
        {
            keyPad.SetActive(false);
            keypadScreen = false;
            onTrigger = false;
        }
        else
        {
            Time.timeScale = 1;
            keyPad.SetActive(false);
            keypadScreen = false;
            onTrigger = true;
            input = "";
            keyPadMessage.SetActive(false);
        }
        
    }
}

