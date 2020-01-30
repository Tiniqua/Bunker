using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemyHealth;
    public int enemyDamage;
    public int bossHealth;
    public int enemySpawnMaxRate;
    public float fireDamageRate;
    public int difficulty;

    static private GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
            instance = this;
    }
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (difficulty == 0)
        {
            enemyHealth = 1;
            enemyDamage = 5;
            bossHealth = 5; 
            enemySpawnMaxRate = 7;
            fireDamageRate = 1f;
        }
        if (difficulty == 1)
        {
            enemyHealth = 3;
            enemyDamage = 10;
            bossHealth = 10;
            enemySpawnMaxRate = 5;
            fireDamageRate = 2f;
        }
        if (difficulty == 2)
        {
            enemyHealth = 5;
            enemyDamage = 20;
            bossHealth = 15;
            enemySpawnMaxRate = 4;
            fireDamageRate = 0.5f;
        }
    }
}
