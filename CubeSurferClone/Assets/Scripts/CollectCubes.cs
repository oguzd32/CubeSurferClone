using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCubes : MonoBehaviour
{
    [SerializeField] private Transform playerObject;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private float offSetY = 0.5f;

    CubeHealth health;

    private void Start()
    {
        health = GetComponent<CubeHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grow")
        {
            GameObject cube = ObjectPooling.Instance.Get();
            cube.transform.parent = parentObject.transform;
            cube.gameObject.SetActive(true);
            health.currentCubeAmount++;
            Destroy(other.gameObject);
            playerObject.transform.position = new Vector3(transform.position.x, 1f + transform.position.y + offSetY * health.currentCubeAmount, transform.position.z);
        }
    }
}
