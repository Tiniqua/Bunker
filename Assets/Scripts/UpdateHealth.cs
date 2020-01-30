using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour
{
    public Slider healthSlider;
    private GameObject player;
    public int maxHealth;

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        healthSlider.value = player.GetComponent<PlayerController>().health;
        if (healthSlider.value >= maxHealth)
        {
            healthSlider.value = maxHealth;
        }
    }
}
