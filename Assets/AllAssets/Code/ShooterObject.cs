using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShooterObject : MonoBehaviour
{
    public GameObject ObjectToShoot;
    public WhatPlayer playerNum;


    void Start()
    {
        Shoot();
    }



    void Update()
    {
        
    }

    void Shoot()
    {
        Instantiate(ObjectToShoot, transform.position, transform.rotation);
    }
}
