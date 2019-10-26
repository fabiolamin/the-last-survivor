using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField]
    private float speedMovement = 5f;
    [SerializeField]
    private float speedRotation = 2f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        Vector3 move = Vector3.zero;
        move += playerInput.GetHorizontalAndVerticalKeys();
        transform.position += move * Time.deltaTime * speedMovement;
    }

    public void Rotate()
    {
        float horizontal = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, horizontal, 0) * speedRotation;
        transform.Rotate(rotation);
    }
}
