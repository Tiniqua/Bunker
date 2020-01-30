using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    private GameObject keyCards;
    public GameObject doorLockedMessage;
    public GameObject unlockDoorMessage;
    private bool canOpenDoor;

    private void Start()
    {
        keyCards = GameObject.Find("KeyCards");
        //doorLockedMessage = GameObject.Find("DoorLockedPanel");
        //unlockDoorMessage = GameObject.Find("UnlockDoorPanel");
    }

    private void Update()
    {
        if (canOpenDoor && Input.GetKeyDown(KeyCode.E))
        {
            UnlockDoor();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (keyCards.GetComponent<DoorControl>().redKeyCard)) //If the player is within the range of the red door and they have collected the red keycard
        {
            unlockDoorMessage.SetActive(true);
            canOpenDoor = true;
        }
        if (other.tag == "Player" && (!keyCards.GetComponent<DoorControl>().redKeyCard)) //If the player is within the range of the red door and they have not collected the red keycard
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

    private void UnlockDoor()
    {
        Debug.Log("Opens Red Door");
        unlockDoorMessage.SetActive(false);
        Destroy(this.gameObject);
    }
}
