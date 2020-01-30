using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    public float waitTime;
    private float currentTime;
    private bool shot;
    private bool withinRange;

    public GameObject player;
    public GameObject bullet;
    public GameObject Boss;

    public Transform bulletSpawnPoint;
    private Transform bulletSpawned;
    AudioSource audioData;

    public void Start()
    {
        withinRange = false;


        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Update()
    {
        if (!bulletSpawnPoint)
        {
            bulletSpawnPoint = this.transform.GetChild(2);
        }

        this.transform.LookAt(player.transform);

        if (withinRange)
        {
            if (currentTime == 0)
            {
                Shoot();
            }

            if (shot && (currentTime < waitTime))
            {
                currentTime += 1 * Time.deltaTime;
            }

            if (currentTime >= waitTime)
            {
                currentTime = 0;
            }
        }

        if (Boss.GetComponent<BigBoss>().BossDied)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player inside boss room");
            withinRange = true;
        }
    }

    public void Shoot()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        shot = true;
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.transform.rotation = this.transform.rotation;

    }

}