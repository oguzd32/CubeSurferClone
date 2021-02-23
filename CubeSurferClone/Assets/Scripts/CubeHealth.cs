using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHealth : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform boy;
    [SerializeField] private ObjectPooling pool;
    [SerializeField] int maxCubeCount = 30;
    [SerializeField] int cubeAmountAtStart = 3;
    [SerializeField] float offSetY;

    public int currentCubeAmount { get; set; } = 0;


    void Start()
    {
        for (int i = 0; i < cubeAmountAtStart; i++)
        {
            var cube = ObjectPooling.Instance.Get();
            cube.transform.parent = gameObject.transform;
            cube.gameObject.SetActive(true);
            currentCubeAmount++;
        }
    }
}
