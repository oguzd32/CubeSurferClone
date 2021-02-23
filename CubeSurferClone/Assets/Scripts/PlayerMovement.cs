using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float moveDirection = 0f;
    [SerializeField] private float screenWidthtInUnits = 16f;
    [SerializeField] private float minX = -1.5f;
    [SerializeField] private float maxX = 1.5f;

    public GameObject parent;

    private Vector3 direction;
    private CubeHealth health;
    private CharacterController characterController;

    void Start()
    {
        health = GetComponent<CubeHealth>();
        characterController = GetComponent<CharacterController>();
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
}
