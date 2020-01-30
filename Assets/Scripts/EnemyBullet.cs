using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;
    public float maxDistance;
    private GameObject player;

    private GameObject triggeringEnemy;
    private GameObject boss;
    private GameObject bossEnemy;
    public int damage;

    void Start()
    {
        damage = GameManager.Instance.enemyDamage;
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossEnemy = GameObject.FindGameObjectWithTag("BossEnemy");
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5)
        {
            Destroy(this.gameObject);
        }

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("hit player");
            Destroy(this.gameObject);

            player.GetComponent<PlayerController>().health -= damage;
        }

        if (other.tag == "Wall")
        {
            Debug.Log("TouchWall");
            Destroy(this.gameObject);
        }
    }
}
