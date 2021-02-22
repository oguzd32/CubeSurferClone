using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoint { get; set; } = 3;

    [SerializeField] private GameObject[] cubes;
}
