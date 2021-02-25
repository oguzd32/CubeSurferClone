using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeHealth : MonoBehaviour
{
    public int currentCubeAmount { get; set; } = 1;

    public void DealDamage()
    {
        currentCubeAmount--;
        if (currentCubeAmount <= 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
