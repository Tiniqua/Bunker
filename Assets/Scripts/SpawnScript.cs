using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private float minTime;
    private float maxTime;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject spawnPoint;


    private float timeDelta = 0;

    public bool canSpawn;

    void Start()
    {
        maxTime = GameManager.Instance.enemySpawnMaxRate;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        canSpawn = false;
        timeDelta = Random.Range(minTime, maxTime);
    }

    
    void Update()
    {
        if (timeDelta > 0 && canSpawn == true)
        {
            timeDelta -= Time.deltaTime;
            if (timeDelta <= 0)
            {
               

                Vector3 pos = spawnPoint.transform.position;
                GameObject enemy = Spawn(pos);

                timeDelta = Random.Range(minTime, maxTime);
            }
        }
    }

    public GameObject Spawn(Vector3 pos)
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Length);

        return (GameObject)Instantiate(enemyPrefab[randomEnemy], pos, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canSpawn = true;
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
