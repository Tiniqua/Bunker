using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static int health;
    private int maxHealth = 10;

    void Start()
    {
        health = maxHealth;
    }
    

}
