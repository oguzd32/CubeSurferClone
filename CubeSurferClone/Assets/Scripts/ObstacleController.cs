using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private Transform playerObject;

    private bool once = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cube")
        {
            if (once==false)
            {
                once = true;
                int objectIndex = FindObjectOfType<CubeHealth>().currentCubeAmount;
                GameObject destroyObject = GameObject.FindGameObjectWithTag("CubeParent").transform.GetChild(objectIndex - 1).gameObject;
                FindObjectOfType<PlayerMovement>().RemoveCube(destroyObject);
                once = true;
                GameObject.FindGameObjectWithTag("Boy").transform.position -= new Vector3(0, 0.5f, 0);
            }

        }
    }
}
