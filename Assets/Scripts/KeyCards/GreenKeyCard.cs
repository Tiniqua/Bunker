using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKeyCard : MonoBehaviour
{
    private GameObject keyCards;
    private bool pickUpAllowed;
    public GameObject pickUpKeyPanel;
    public GameObject GreenUI;

    private void Start()
    {
        keyCards = GameObject.Find("KeyCards");
        pickUpAllowed = false;
        GreenUI.SetActive(true);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUpKeyCard();
            GreenUI.SetActive(false);
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
        Debug.Log("Interacts with red key card");
        Destroy(this.gameObject);
        pickUpKeyPanel.SetActive(false);
        keyCards.GetComponent<DoorControl>().greenKeyCard = true;

    }
}
