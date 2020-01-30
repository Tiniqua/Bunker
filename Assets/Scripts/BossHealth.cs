using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public static int health;
    private int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
    }


}
