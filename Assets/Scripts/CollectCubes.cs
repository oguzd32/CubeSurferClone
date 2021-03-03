using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCubes : MonoBehaviour
{
    [SerializeField] private Transform playerObject;
    [SerializeField] private GameObject parentObject;


    public static CollectCubes instance; 
    private bool isColliding = true;
    int i = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void LateUpdate()
    {
        if (i>0)
        {
            isColliding = true;
            i = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grow")
        {
            if (isColliding)
            {
                isColliding = false;
                //GameObject cube = ObjectPooling.Instance.Get();
                ObjectPooling.Instance.ShowCube();
                /*int _index = CubeHealth.currentCubeAmount;
                GameObject lastCube = parentObject.transform.GetChild(_index - 1).gameObject;
                cube.transform.parent = parentObject.transform;
                cube.transform.position = new Vector3(transform.position.x, lastCube.transform.position.y + 1, transform.position.z);
                
                cube.gameObject.SetActive(true);*/
                Destroy(other.gameObject);
                //playerObject.transform.position += new Vector3(0, 1, 0); // increase 1 unit when adding 1 cube
                playerObject.transform.localPosition = (Vector3.up * ObjectPooling.Instance.returnActiveCubes()) + Vector3.up;
                CubeHealth.currentCubeAmount++;
                i++;
            }
        }
    }

    public void CollectCubeF()
    {
        ObjectPooling.Instance.ShowCube();
        playerObject.transform.localPosition = (Vector3.up * ObjectPooling.Instance.returnActiveCubes()) + Vector3.up;
        CubeHealth.currentCubeAmount++;
    }
    public void LooseCube()
    {
        playerObject.transform.localPosition = (Vector3.up * ObjectPooling.Instance.returnActiveCubes()) + Vector3.up;
    }
}
