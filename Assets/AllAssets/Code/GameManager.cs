using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public WhatPlayer winner;
    public UnityAction gameEndAction;
    

    void Awake()
    {
        gameEndAction += GameEndEvent;
    }

    public void GameEndEvent()
    {
        Debug.LogWarning("Game over: " + winner.ToString() + " won.");
    }

}
