using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    [SerializeField] private int multipleScore;

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
                GameObject destroyObject = GameObject.FindGameObjectWithTag("CubeParent").transform.GetChild(i).gameObject;
                playerMovement.RemoveCube(destroyObject);
                FindObjectOfType<GameSession>().AddToScore(multipleScore);
                once = false;
                i++;
            }
        }
    }
}
