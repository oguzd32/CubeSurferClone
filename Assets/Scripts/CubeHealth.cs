using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHealth : MonoBehaviour
{
    public static int currentCubeAmount { get; set; }
    public static bool canDie;

    private void Start()
    {
        canDie = false;
        currentCubeAmount = 1;
    }

    public void DealDamage(int damage)
    {
        currentCubeAmount -= damage;
        Debug.Log("Your cube amount: " + currentCubeAmount);
        if (currentCubeAmount <= 0)
        {
            Debug.Log("You are dead, your cube amount: " + currentCubeAmount);
            GameSession.youLose = true;
        }
    }
}
