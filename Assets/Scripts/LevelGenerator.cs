using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static int currentLevel = 1;

    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject collactableCube;
    [SerializeField] private GameObject obstacleCubeSet;
    [SerializeField] private GameObject doubleObstacleCubeSet;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject finishLine;
    [SerializeField] private GameObject[] finisgGameObjects;

    void Start()
    {
        GenerateGround();
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        GenerateCoin();
        GenerateCollactableCube();
        GenerateFinishGameObjects();
        GenerateFinishLine();
        GenerateObstacleCubes();
    }

    #region Generation Methods
    private void GenerateGround()
    {
        GameObject _ground = Instantiate(ground, new Vector3(0, 0, 0), Quaternion.identity);
        _ground.transform.localScale = new Vector3(1, 1, currentLevel * 7 );
        _ground.transform.position = new Vector3(0, 0, _ground.transform.localScale.z * 5);
    }

    private void GenerateCoin()
    {
        int coinAmount = 8;
        int z = 0;

        for (int i = 0; i < coinAmount; i++)
        {
            Instantiate(coin, new Vector3(0, 1, 5 + z), Quaternion.Euler(-90, 0, 0));
            z += 2;
        }

        int coinAmount2 = 6;
        int z1 = 0;

        for (int i = 0; i < coinAmount2; i++)
        {
            Instantiate(coin, new Vector3(-3, 1, (52 * currentLevel) + z), Quaternion.Euler(-90, 0, 0));
            Instantiate(coin, new Vector3(3, 1, (52 * currentLevel) + z), Quaternion.Euler(-90, 0, 0));
            z1 -= 3;
        }
    }

    private void GenerateCollactableCube()
    {
        int collactableCubeAmount = 0;

        for (float z = 5; z <= currentLevel * 45; z += 10)
        {
            if(collactableCubeAmount >= currentLevel * 15) { return; }

            if (collactableCubeAmount > 12)
            {
                Instantiate(collactableCube, new Vector3(-2, 0.5f, z + 10), Quaternion.identity);
                collactableCubeAmount++;
            }

            if (collactableCubeAmount > 4)
            {
                Instantiate(collactableCube, new Vector3(2, 0.5f, z + 10), Quaternion.identity);
                collactableCubeAmount++;
            }
            else
            {
                Instantiate(collactableCube, new Vector3(-1, 0.5f, z), Quaternion.identity);
                collactableCubeAmount++;
            }
        }

        int z2 = 0;
        for (int i = 0; i < 4; i++)
        {
            Instantiate(collactableCube, new Vector3(-1.5f, 0.5f, 45 + z2), Quaternion.identity);
            Instantiate(collactableCube, new Vector3(1.5f, 0.5f, 45 + z2), Quaternion.identity);
            z2 += 3;
        }
    }

    private void GenerateFinishLine()
    {
        Instantiate(finishLine, new Vector3(0, 0, 70 * currentLevel - 10), Quaternion.identity);
    }

    private void GenerateFinishGameObjects()
    {
        for (int i = 0; i < finisgGameObjects.Length; i++)
        {
            Instantiate(finisgGameObjects[i], new Vector3(0, i * 0.5f, 2.5f + 70 * currentLevel + i * 5), Quaternion.identity);
        }
    }

    private void GenerateObstacleCubes()
    {
        int obstacleAmount = 0;
        for (int z = 20; z < 60 * currentLevel; z += 20)
        {
            if(obstacleAmount > 4 * currentLevel) { return; }

            if (obstacleAmount > 4)
            {
                Instantiate(doubleObstacleCubeSet, new Vector3(0, 0.5f, z + 10), Quaternion.identity);
                obstacleAmount += 2;
            }
            else
            {
                Instantiate(obstacleCubeSet, new Vector3(0, 0.5f, z), Quaternion.identity);
                obstacleAmount++;
            }
        }
    }

    #endregion
}
