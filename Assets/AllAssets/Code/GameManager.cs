using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public WhatPlayer winner;
    public UnityAction gameEndAction;
    public UnityEvent eventGameEnd;

    void Awake()
    {
        gameEndAction += GameEndEvent;
    }

    private void GameEndEvent()
    {
        eventGameEnd.Invoke();
        Debug.LogWarning("Game over: " + winner.ToString() + " won.");
    }

}
