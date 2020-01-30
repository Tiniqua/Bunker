using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    private GameObject boss;
    public int maxHealth;

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    private void Update()
    {
        healthSlider.value = boss.GetComponent<BigBoss>().health;
        if (healthSlider.value >= maxHealth)
        {
            healthSlider.value = maxHealth;
        }
    }
}
