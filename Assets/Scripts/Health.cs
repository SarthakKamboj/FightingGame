using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector]
    public int health;
    public int maxHealth = 100;
    void Start()
    {
        health = maxHealth;
    }

    
}
