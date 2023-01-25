using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name== "Ball")
        {
            _gameManager.Dead();
        }
    }
}

