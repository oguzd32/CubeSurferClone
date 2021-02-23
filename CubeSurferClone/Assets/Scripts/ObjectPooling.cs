using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float height = 1f;

    private Queue<GameObject> cubes = new Queue<GameObject>();

    public static ObjectPooling  Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public GameObject Get()
    {
        if (cubes.Count == 0)
        {
            AddCubes(1);
        }

        return cubes.Dequeue();
    }

    private void AddCubes(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject cube = Instantiate(cubePrefab,
                                          new Vector3(transform.position.x, i + 0.5f, transform.position.z),
                                          Quaternion.identity);
            cube.gameObject.SetActive(false);
            cubes.Enqueue(cube);
        }
    }

    public void ReturnToPool(GameObject cube)
    {
        cube.gameObject.SetActive(false);
        cubes.Enqueue(cube);
    }
}
                                     