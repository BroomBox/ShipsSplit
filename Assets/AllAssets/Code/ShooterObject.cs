using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShooterObject : MonoBehaviour
{
    public WhatPlayer playerNum;

    [SerializeField] public GameObject ObjectToShoot;

    [SerializeField] Transform shootOrigin;

    [SerializeField] private TrajectorylLine trajectoryLine;

    [SerializeField] private float bombMass = 30;

    [SerializeField] private float shotForce = 30;

    [SerializeField] private float shootDelay = 1f;

    private bool isWaiting = false;


    void Start()
    {

    }



    void Update()
    {
        trajectoryLine.ShowTrajectoryLine(shootOrigin.position, shootOrigin.forward * shotForce / bombMass);
        if (Input.GetKeyDown(KeyCode.Space) && isWaiting == false)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bomb = Instantiate(ObjectToShoot);
        bomb.transform.position = shootOrigin.position;
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.mass = bombMass;
        rb.AddForce(shootOrigin.forward * shotForce, ForceMode.Impulse);
        isWaiting = true;
        StartCoroutine(DelayShooting());
    }

    private IEnumerator DelayShooting()
    {
        yield return new WaitForSeconds(shootDelay);
        isWaiting = false;
    }
}
