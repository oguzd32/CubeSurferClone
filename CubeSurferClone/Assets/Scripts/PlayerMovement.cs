using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float moveDirection = 0f;
    [SerializeField] private float screenWidthtInUnits = 16f;
    [SerializeField] private float minZ = 1f;
    [SerializeField] private float maxZ = 5f;

    private Vector3 direction;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.x = -forwardSpeed;
        direction.z = Mathf.Clamp(GetZPos(), minZ, maxZ);
    }

    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }

    private float GetZPos()
    {
        return Input.mousePosition.x / Screen.width * screenWidthtInUnits;
    }
}
