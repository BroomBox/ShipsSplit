using System.Collections;
using UnityEngine;


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

    private float _shotForce;
    
    [SerializeField] private float baseShotForce = 50;

    [SerializeField]
    private float shotForceIncrease = 2f;
    
    [SerializeField] private float shootDelay = 1f;

    
    
    private KeyCode _inputKey;
    
    private bool _isWaiting = false;

    private bool _input;

    private void Start()
    {
        _shotForce = baseShotForce;
        MapInput();
    }

    void Update()
    {
        PlayersShoot();
    }



    private void MapInput()
    {
        switch (playerNum)
        {
            case WhatPlayer.Player1:
                _inputKey = KeyCode.Space; // space key
                break;
            case WhatPlayer.Player2:
                _inputKey = KeyCode.Return; // enter key
                break;
        }
    }

    private void PlayersShoot()
    {
        ShowDaeLine();
        if (Input.GetKey(_inputKey)) IncreaseForce();
        
        if (Input.GetKeyUp(_inputKey) && _isWaiting == false) Shoot();
    }


    void IncreaseForce()
    {
        _shotForce += shotForceIncrease;
    }

    void ShowDaeLine()
    {
        if (Input.GetKeyDown(_inputKey))
            trajectoryLine.ShowTrajectoryLine(shootOrigin.position, shootOrigin.forward * _shotForce / bombMass);
        else
            trajectoryLine.HideTrajectoryLine();
    }

    void Shoot()
    {
        GameObject bomb = Instantiate(objectToShoot);
        bomb.transform.position = shootOrigin.position;

        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.mass = bombMass;
        rb.AddForce(shootOrigin.forward * _shotForce, ForceMode.Impulse);

        Projectile projectile = bomb.GetComponent<Projectile>();
        projectile.projectileOwner = playerNum;
        
        _isWaiting = true;
        _shotForce = baseShotForce;
        StartCoroutine(DelayShooting());
    }

    private IEnumerator DelayShooting()
    {
        yield return new WaitForSeconds(shootDelay);
        _isWaiting = false;
    }
}
