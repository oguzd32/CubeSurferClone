using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float screenWidthtInUnits = 16f;
    [SerializeField] private float minX = -1.5f;
    [SerializeField] private float maxX = 1.5f;

    private Vector3 direction;

    // cached components
    private ObjectPooling pool;
    private CubeHealth health;
    public CharacterController characterController;

    void Start()
    {
        health = GetComponent<CubeHealth>();
        characterController = GetComponent<CharacterController>();
        pool = GetComponent<ObjectPooling>();
    }

    void Update()
    {
        direction.z = forwardSpeed;
        direction.x = Mathf.Clamp(GetXPos(), minX, maxX);
    }

    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }

    private float GetXPos()
    {
        return Input.mousePosition.x / Screen.width * screenWidthtInUnits;
    }

    public void RemoveCube(GameObject cube)
    {
        health.DealDamage();
        pool.ReturnToPool(cube);
    }
}
