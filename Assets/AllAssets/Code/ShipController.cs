using UnityEngine;

[System.Serializable]
public enum WhatPlayer
{
    Player1,
    Player2, 
    None
}

public class ShipController : MonoBehaviour
{
    CharacterController _controller;

    public WhatPlayer playerNum;

    public float speed = 6f;
    public float turnSpeed = 15f;
    

    Vector2 _input;

    Vector3 _velocity;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        // get input
        switch (playerNum)
        {
            case WhatPlayer.Player1:
                PlayerOneInput();
                break;
            case WhatPlayer.Player2:
                PlayerTwoInput();
                break;
        }
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
        _velocity = transform.forward * _input.y;
        transform.Rotate(Vector3.up * (_input.x * turnSpeed * Time.deltaTime));
        _controller.Move(speed * Time.deltaTime * _velocity);
    }
}
