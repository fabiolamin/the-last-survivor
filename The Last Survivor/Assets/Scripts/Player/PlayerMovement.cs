using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private Rigidbody playerRigidbody;
    private Vector3 move;
    [SerializeField]
    private float speedMovement = 5f;
    [SerializeField]
    private float speedRotation = 2f;
    
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        move = transform.forward * vertical * speedMovement;
        playerRigidbody.MovePosition(playerRigidbody.position + move);
        playerAnimation.Move(vertical);
    }

    public void Rotate()
    {
        float horizontal = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, horizontal, 0) * speedRotation;
        playerRigidbody.MoveRotation(Quaternion.Euler(playerRigidbody.rotation.eulerAngles + rotation));
    }
}
