using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDoor : MonoBehaviour
{
    private GameObject keyCards;
    public GameObject doorLockedMessage;
    public GameObject unlockDoorMessage;
    private bool canOpenDoor;
    private bool DoorOpened;
    public Animation OpenDoor;


    private void Start()
    {
        keyCards = GameObject.Find("KeyCards");
        OpenDoor = GetComponent<Animation>();
    }

    private void Update()
    {
        if (!DoorOpened && canOpenDoor && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Opens Green Door");
            unlockDoorMessage.SetActive(false);
            //OpenDoor.Play();
            DoorOpened = true;
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (keyCards.GetComponent<DoorControl>().greenKeyCard)) //If the player is within the range of the red door and they have collected the red keycard
        {
            unlockDoorMessage.SetActive(true);
            canOpenDoor = true;
        }
        if (other.tag == "Player" && (!keyCards.GetComponent<DoorControl>().greenKeyCard)) //If the player is within the range of the red door and they have not collected the red keycard
        {
            doorLockedMessage.SetActive(true);
        }

    }

    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            doorLockedMessage.SetActive(false);
            unlockDoorMessage.SetActive(false);
            canOpenDoor = false;
        }
    }
}
