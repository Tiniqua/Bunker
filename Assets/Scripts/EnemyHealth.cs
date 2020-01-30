using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    private int currentHealth;

    public event Action <float> OnHealthPctChanged = delegate { };

    private void OnEnabled()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }
 


   
}
