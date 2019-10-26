using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody playerRigidbody;
    [SerializeField]
    private float speedMovement = 5f;
    [SerializeField]
    private float speedRotation = 2f;
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        Vector3 move = Vector3.zero;
        move += playerInput.GetHorizontalAndVerticalKeys() * speedMovement;
        playerRigidbody.MovePosition(playerRigidbody.position + move);
    }

    public void Rotate()
    {
        float horizontal = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, horizontal, 0) * speedRotation;
        playerRigidbody.MoveRotation(Quaternion.Euler(playerRigidbody.rotation.eulerAngles + rotation));
    }
}
