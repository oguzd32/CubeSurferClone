using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] private int pointPerCoin = 10;

    private void OnTriggerEnter(Collider other)
    {
        // add score in UI
        FindObjectOfType<GameSession>().AddToScore(pointPerCoin);

        Destroy(gameObject);
    }
}
