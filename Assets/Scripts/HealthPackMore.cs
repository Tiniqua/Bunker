using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackMore : MonoBehaviour
{
    private GameObject player;
    //private GameObject collectHealthPanel;
    public GameObject collectHealthPanel;
    private bool pickUpAllowed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUpHealth();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collectHealthPanel.SetActive(true);
            pickUpAllowed = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            collectHealthPanel.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUpHealth()
    {
        Debug.Log("Interacts with Health bar");
        Destroy(this.gameObject);
        collectHealthPanel.SetActive(false);
        player.GetComponent<PlayerController>().health += 50;
    }
}
