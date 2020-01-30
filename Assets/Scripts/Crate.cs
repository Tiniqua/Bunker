using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{

    public Animation openCrate;
    public GameObject OpenCrateMessage;
    private bool canOpenCrate;
    private bool crateOpened;

    private void Start()
    {
        openCrate = GetComponent<Animation>();
    }
    private void Update()
    {
        if (!crateOpened && canOpenCrate && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Open Crate");
            OpenCrateMessage.SetActive(false);
            openCrate.Play();
            crateOpened = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !crateOpened) 
        {
            OpenCrateMessage.SetActive(true);
            canOpenCrate = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !crateOpened)
        {
            OpenCrateMessage.SetActive(false);
            canOpenCrate = false;
        }
    }
}
