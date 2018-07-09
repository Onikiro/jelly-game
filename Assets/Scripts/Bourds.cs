using System;
using UnityEngine;

public class Bourds : MonoBehaviour
{
    public static event Action OnGameOver;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameEvents.Send(OnGameOver);
        }
    }
}
