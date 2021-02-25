using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    private int i = 0;
    private bool once = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {        
            if(once == false)
            {
                once = true;
                PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();

                int objectIndex = FindObjectOfType<CubeHealth>().currentCubeAmount;
                GameObject destroyObject = GameObject.FindGameObjectWithTag("CubeParent").transform.GetChild(i).gameObject;
                playerMovement.RemoveCube(destroyObject);
                once = false;
                i++;
            }
        }
    }
}
