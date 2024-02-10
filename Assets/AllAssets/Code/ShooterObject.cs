using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


/// <summary>
/// What in the actual fuck are those namespaces
/// </summary>

public class ShooterObject : MonoBehaviour
{
    public WhatPlayer playerNum;


    // public are by default serialized yk
    public GameObject objectToShoot;

    [SerializeField] private Transform shootOrigin;

    [SerializeField] private TrajectorylLine trajectoryLine;

    [SerializeField] private float bombMass = 30;

    [SerializeField] private float shotForce = 30;

    [SerializeField] private float shootDelay = 1f;

    private bool _isWaiting = false;

    private bool _input;

    void Update()
    {
        GetInput();
        PlayersShoot();
    }



    private void GetInput()
    {
        switch (playerNum)
        {
            case WhatPlayer.Player1:
                _input = Input.GetKey(KeyCode.Space); // space key
                break;
            case WhatPlayer.Player2:
                _input = Input.GetKey(KeyCode.Return); // enter key
                break;
        }
    }

    private void PlayersShoot()
    {
        ShowDaeLine();
        if (_input && _isWaiting == false) Shoot();
    }

    void ShowDaeLine()
    {
        if (_input)
            trajectoryLine.ShowTrajectoryLine(shootOrigin.position, shootOrigin.forward * shotForce / bombMass);
        else
            trajectoryLine.HideTrajectoryLine();
    }

    void Shoot()
    {
        GameObject bomb = Instantiate(objectToShoot);
        bomb.transform.position = shootOrigin.position;

        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.mass = bombMass;
        rb.AddForce(shootOrigin.forward * shotForce, ForceMode.Impulse);

        Projectile projectile = bomb.GetComponent<Projectile>();
        projectile.projectileOwner = playerNum;

        _isWaiting = true;
        StartCoroutine(DelayShooting());
    }

    private IEnumerator DelayShooting()
    {
        yield return new WaitForSeconds(shootDelay);
        _isWaiting = false;
    }
}
