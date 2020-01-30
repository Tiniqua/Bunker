
using UnityEngine;
using System.Collections;
using System;
public class BigBoss : MonoBehaviour
{
    public int scoreValue = 5;
    public int health;
    private GameObject bossForcefield;
    ScoreManager SM = new ScoreManager();
    public GameObject winScreen;
    public bool BossDied;
    


    private void Start()
    {
        BossDied = false;
        bossForcefield = GameObject.Find("BossForceField");
        health = 100;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        if(health <= 20)
        {
            Destroy(bossForcefield);
        }
    }

    private void Die()
    {
        ScoreManager.finalScore = ScoreManager.score;

        KillsManager.score += scoreValue;
        ScoreManager.score += scoreValue;
        
        print("You've won!");
        SM.SaveFile();
        Destroy(this.gameObject);
        winScreen.SetActive(true);
        Time.timeScale = 0f;
        BossDied = true;
    }
}
