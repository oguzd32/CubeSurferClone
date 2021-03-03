using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;

    //private Queue<GameObject> cubes = new Queue<GameObject>();
    public GameObject CubeParent;
    public static ObjectPooling Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        CreatePool(50);
    }
 
   /* public GameObject Get()
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
            GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);

            cube.gameObject.SetActive(false);
            cubes.Enqueue(cube);
        }
    }

    public void ReturnToPool(GameObject cube)
    {
        cube.gameObject.SetActive(false);
        cubes.Enqueue(cube);
    }*/

    #region Yeni Kodlar
    public int returnActiveCubes()
    {
        int activeVal = 0;

        for (int i = 0; i < CubeParent.transform.childCount; i++)
        {
            if (CubeParent.transform.GetChild(i).gameObject.activeSelf)
            {
                activeVal++;
            }
        }
        return activeVal;
    }

    public void CreatePool(int val)
    {
        for(int i = 0; i< val; i++)
        {
            GameObject cubeIns =  Instantiate(cubePrefab, CubeParent.transform);
            cubeIns.SetActive(false);
            cubeIns.transform.localPosition = Vector3.up * CubeParent.transform.childCount;
        }
    }

    public void ShowCube()
    {
        int activeVal = 0;

        for(int i = 0; i< CubeParent.transform.childCount; i++)
        {
            if (CubeParent.transform.GetChild(i).gameObject.activeSelf)
            {
                activeVal++;
            }
        }

        if(activeVal < CubeParent.transform.childCount)
        {
            CubeParent.transform.GetChild(activeVal).gameObject.SetActive(true);
        }
    }


    public void DontShowCube(int sutunVal)
    {

        int activeVal = 0;

        for (int i = 0; i < CubeParent.transform.childCount; i++)
        {
            if (CubeParent.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                activeVal++;
            }
        }

        if(sutunVal < activeVal)
        {
            for (int i = 0; i < sutunVal; i++)
            {
                CubeParent.transform.GetChild(activeVal - 1 - i).gameObject.SetActive(false);
            }
        }
    }
    #endregion
}