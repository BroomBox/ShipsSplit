using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Destroyable
{
    public WhatPlayer whatPlayer;

    // Start is called before the first frame update
    void Start()
    {
        SetupHealth();
    }

    public override void TakeDamage(int damage, WhatPlayer whoHitThat)
    {
        health -= damage;
        
        if (health <= 0)
        {
            GameManager manager = FindObjectOfType<GameManager>();

            if (manager != null)
            {
                manager.winner = whoHitThat;
                manager.gameEndAction.Invoke();
                Destroy(this.gameObject);
            }
        }
    }
}
