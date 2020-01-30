
using UnityEngine;
using System.Collections;
using System;
public class BigBoss : MonoBehaviour
{
    public int health;

    public void Start()
    {
        health = GameManager.Instance.bossHealth;

    }
    public void Update()
    {

        if (health <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Debug.Log(this.gameObject.name + " has died");
        Destroy(this.gameObject);
        gameObject.GetComponent<TurretController>().Die();
    }
}
