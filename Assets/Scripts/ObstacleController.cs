using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private bool isColliding = true;

    [SerializeField] private GameObject cubePrefab;

    public int ObstacleHeight = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cube")
        {
            if (isColliding)
            {
                isColliding = false;

                ObjectPooling.Instance.DontShowCube(ObstacleHeight);
                CollectCubes.instance.LooseCube();

                FindObjectOfType<CubeHealth>().DealDamage(ObstacleHeight);

                if(CubeHealth.currentCubeAmount <= 0) { return; }

                // when encounter a obstacle drop a cube
                Transform dropCube = other.gameObject.transform;

                for (int i = 0; i < ObstacleHeight; i++)
                {
                    Vector3 dropPos = new Vector3(dropCube.position.x, 0.5f + i, dropCube.position.z);

                    Instantiate(cubePrefab, dropPos, Quaternion.identity);

                    GameObject.FindGameObjectWithTag("Boy").transform.position += Vector3.up;
                    GameObject.FindGameObjectWithTag("CubeParent").transform.position += Vector3.up;
                }


                StartCoroutine(PlayerDown());
            }
        }   
    }

    IEnumerator PlayerDown()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject.FindGameObjectWithTag("Boy").transform.position += Vector3.down * ObstacleHeight;
        GameObject.FindGameObjectWithTag("CubeParent").transform.position += Vector3.down * ObstacleHeight;
    }
}
