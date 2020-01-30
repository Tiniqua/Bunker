using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNearbyCheck : MonoBehaviour
{
    public bool canSpawn;


    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canSpawn = true;
        }
    }
}
