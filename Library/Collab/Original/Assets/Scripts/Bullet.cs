using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float maxDistance;
    private GameObject player;

    private GameObject triggeringEnemy;
    public int damage;
    
    void Start()
    {
        damage = GameManager.Instance.enemyDamage; 
        player = GameObject.FindGameObjectWithTag("Player");
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

        if (other.tag == "Player")
        {
            Debug.Log("hit player");
            Destroy(this.gameObject);

            player.GetComponent<PlayerController>().health -= damage;
        }

        if (other.tag == "Wall")
        {
            Debug.Log("TouchWall");
            Destroy(this.gameObject); // this is dumb
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
