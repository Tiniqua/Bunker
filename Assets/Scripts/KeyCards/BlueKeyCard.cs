using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKeyCard : MonoBehaviour
{
    private GameObject keyCards;
    private bool pickUpAllowed;
    public GameObject pickUpKeyPanel;
    public GameObject blueUI;

    private void Start()
    {
        keyCards = GameObject.Find("KeyCards");
        pickUpAllowed = false;
        blueUI.SetActive(true);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUpKeyCard();
            blueUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickUpKeyPanel.SetActive(true);
            pickUpAllowed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pickUpKeyPanel.SetActive(false);
            pickUpAllowed = false;
        }
    }
    private void PickUpKeyCard()
    {
        Debug.Log("Interacts with blue key card");
        Destroy(this.gameObject);
        pickUpKeyPanel.SetActive(false);
        keyCards.GetComponent<DoorControl>().blueKeyCard = true;

    }
}
