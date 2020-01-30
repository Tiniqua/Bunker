using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private GameObject player;
    private float delay = 0;
    public float damageRate;
    

    // Start is called before the first frame update
    private void Start()
    {
        damageRate = GameManager.Instance.fireDamageRate;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            delay += Time.deltaTime;
           if (delay > damageRate)
            {
                player.GetComponent<PlayerController>().health -= 5;
                delay = 0;
            }
           
        }
    }

   

}
