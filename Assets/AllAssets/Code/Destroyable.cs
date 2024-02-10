using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public int health;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        SetupHealth();
    }


    public virtual void TakeDamage(int damage, WhatPlayer whoHitThat)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this);
        }
    }

    protected void SetupHealth()
    {
        health = maxHealth;
    }


}
