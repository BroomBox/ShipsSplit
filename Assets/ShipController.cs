using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum WhatPlayer
{
    player1,
    player2
}

public class ShipController : MonoBehaviour
{
    CharacterController _controller;
    public WhatPlayer playerNum;
    // Start is called before the first frame update
    
    Vector2 _input;

    Vector3 _velocity;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input
        switch (playerNum)
        {
            case WhatPlayer.player1:
                PlayerOneInput();
                break;
            case WhatPlayer.player2:
                PlayerTwoInput();
                break;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void PlayerOneInput()
    {
        _input.x = Input.GetAxis("p1horizontal");
        _input.y = Input.GetAxis("p1vertical");
    }

    void PlayerTwoInput()
    {
        _input.x = Input.GetAxis("p2horizontal");
        _input.y = Input.GetAxis("p2vertical");
    }

    void Move()
    {
        
    }
}
