using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float maxDistance;
    private GameObject player;
    private GameObject damagedBattery;

    private GameObject triggeringEnemy;
    private GameObject boss;
    private GameObject bossEnemy;
    public int damage;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossEnemy = GameObject.FindGameObjectWithTag("BossEnemy");
        damagedBattery = GameObject.FindGameObjectWithTag("DamagedBattery");
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        maxDistance += 1 * Time.deltaTime;

        if(maxDistance >= 5)
        {
            Destroy(this.gameObject);
        }
      
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
            Debug.Log("HittingEnemy");
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<EnemyController>().health -= 1;
            Destroy(this.gameObject);
        }

        if (other.tag == "BossEnemy")
        {
            Debug.Log("HittingBossEnemy");
            bossEnemy = other.gameObject;
            bossEnemy.GetComponent<MinionController>().health -= 1;
            Destroy(this.gameObject);
        }


        if (other.tag == "Boss")
        {
            Debug.Log("hit boss");
            Destroy(this.gameObject);

            boss.GetComponent<BigBoss>().health -= 5;
        }

        if (other.tag == "Wall" || other.tag == "BlueDoor" || other.tag == "RedDoor" || other.tag == "GreenDoor")
        {
            Debug.Log("TouchWall");
            Destroy(this.gameObject); 
        }

        if (other.tag == "ForceField")
        {
            Debug.Log("TouchForcefield");
            Destroy(this.gameObject);
        }
        if (other.tag == "Battery")
        {

            Debug.Log("HIT");
            other.gameObject.SetActive(false);
            boss.GetComponent<BigBoss>().health -= 20;
            
        }

        if (other.tag == "Boss")
        {
            Debug.Log("HittingBoss");
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<BigBoss>().health -= 1;
            Destroy(this.gameObject);
        }
    }
}
