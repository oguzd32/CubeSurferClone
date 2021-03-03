using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float minX = -1.5f;
    [SerializeField] private float maxX = 1.5f;

    private Vector3 direction;

    // cached components
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        CollectCubes.instance.CollectCubeF();
    }

    void Update()
    {
        if (!GameSession.isGameStarted) { return; }

        direction.z = forwardSpeed;
        direction.x = Mathf.Clamp(GetXPos(), minX, maxX);
    }

    private void FixedUpdate()
    {
        if (!GameSession.isGameStarted) { return; }
        characterController.Move(direction * Time.fixedDeltaTime);

        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -4.5f, 4.5f),
                                      this.transform.position.y,
                                      this.transform.position.z);
    }
    void LateUpdate()
    {
        if (!GameSession.isGameStarted) { return; }
      
        /*
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -4.4f, 4.4f),
                                              this.transform.position.y,
                                              this.transform.position.z);
        */
    }
    private float GetXPos()
    {
        float calc = (Input.mousePosition.x * 9) / Screen.width;
        calc -= 4.5f;
        return calc;
    }
}
