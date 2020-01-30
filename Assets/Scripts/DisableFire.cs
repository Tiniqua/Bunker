using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFire : MonoBehaviour
{
    private GameObject player;
    private bool notPressed = true;
    public GameObject sprinkler;
    public GameObject fireTrap;
    public GameObject sprinklerMess;
    private bool pickUpAllowed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            sprinkler.SetActive(true);
            fireTrap.SetActive(false);
            notPressed = false;

            StartCoroutine(timer());
        }   
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
        sprinkler.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && notPressed)
        {
            sprinklerMess.SetActive(true);
            pickUpAllowed = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            sprinklerMess.SetActive(false);
            pickUpAllowed = false;
        }
    }

}
