using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public WhatPlayer projectileOwner;

    private void OnCollisionEnter(Collision collision)
    {
        Ship ship = collision.gameObject.GetComponent<Ship>();

        if (ship != null)
        {
            if (ship.whatPlayer != projectileOwner)
            {
                ship.TakeDamage(10, projectileOwner);

                Destroy(this.gameObject);
            }
        }
    }
}
