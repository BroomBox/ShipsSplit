using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider[] healthBar = new Slider[2];
    public Ship shipTracked;
    public WhatPlayer whatPlayer;

    private void Start()
    {
        Ship[] ships = FindObjectsOfType<Ship>();

        foreach (var t in ships)
        {
            if (t.whatPlayer == whatPlayer)
            {
                shipTracked = t;
            }
            else return;
        }
        
        foreach (var t in healthBar)
        {
            t.maxValue = shipTracked.maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var t in healthBar)
        {
            t.value = shipTracked.health;
        }
    }
}
