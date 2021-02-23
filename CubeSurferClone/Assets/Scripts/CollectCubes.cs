using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCubes : MonoBehaviour
{
    [SerializeField] private Transform boy;

    CubeHealth health;

    private void Start()
    {
        health = GetComponent<CubeHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grow")
        {
            Debug.Log("grow is trigger");
            GameObject cube = ObjectPooling.Instance.Get();
            cube.transform.parent = gameObject.transform;
            cube.gameObject.SetActive(true);
            health.currentCubeAmount++;
            Destroy(other.gameObject);
            boy.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f * health.currentCubeAmount, transform.position.z);
        }
    }
}
