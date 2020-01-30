using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    [SerializeField] private float minTime;
    private float maxTime;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawnPoint;

    public int minionCount = 0;
    private float timeDelta = 0;

    public bool canSpawn;

    void Start()
    {
        maxTime = 2;// GameManager.Instance.enemySpawnMaxRate;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        canSpawn = false;
        timeDelta = Random.Range(minTime, maxTime);
    }


    void Update()
    {
        if(minionCount <= 2)
            {

            if (timeDelta > 0 && canSpawn == true)
            {
                timeDelta -= Time.deltaTime;

                if (timeDelta <= 0)
                {

                    Vector3 pos = spawnPoint.transform.position;
                    Debug.Log("Call Spawn Enemy");
                    GameObject enemy = Spawn(pos);

                    timeDelta = Random.Range(minTime, maxTime);

                    ++minionCount;
                }
            }

            
        }

    }

    public GameObject Spawn(Vector3 pos)
    {
        Debug.Log("SpawnEnemy");
         return (GameObject)Instantiate(enemyPrefab, pos, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
            Debug.Log(canSpawn = true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canSpawn = false;
        }
    }
}
