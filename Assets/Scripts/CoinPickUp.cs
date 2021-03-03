using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] private int pointPerCoin = 10;

    private bool finishedCoroutine = true;

    private void OnTriggerEnter(Collider other)
    {

        if (finishedCoroutine)
        {
            finishedCoroutine = false;
            StartCoroutine(AddCoin());
        }

    }

    IEnumerator AddCoin()
    {
        // add score in UI
        FindObjectOfType<GameSession>().AddToScore(pointPerCoin);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
