using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeField : MonoBehaviour
{
    private GameObject player;
    private float delay = 0;
    private float damageRate;
    public int minionsKilled;
    public List<GameObject> ForceFields;
    public GameObject MinionSpawner;
    

    // Start is called before the first frame update
    private void Start()
    {
        damageRate = GameManager.Instance.fireDamageRate;
        player = GameObject.FindGameObjectWithTag("Player");
        MinionSpawner = GameObject.Find("MinionSpawner");

    }

    // Update is called once per frame
    void Update()
    {
        //int length = 3;
        if (minionsKilled == 3)
        {
            int randomPoint = Random.Range(0, ForceFields.Count);
            Destroy(ForceFields[randomPoint]);
            ForceFields.RemoveAt(randomPoint);
            //length -= 1;
            
            //this.gameObject.SetActive(false);
            minionsKilled = 0;
            MinionSpawner.GetComponent<MinionSpawner>().minionCount = 0;


        }
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


/// DO NOT CLOSE 