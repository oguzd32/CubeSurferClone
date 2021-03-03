using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBoard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameSession.totalScore += 100;

        GameSession.levelComplete = true;
    }
}
