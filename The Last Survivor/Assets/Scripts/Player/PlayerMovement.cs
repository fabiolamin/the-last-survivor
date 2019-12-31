using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private Rigidbody playerRigidbody;
    private Vector3 move;
    private AudioSource audioSource;
    [SerializeField]
    private float speedMovement = 5f;
    [SerializeField]
    private float speedRotation = 2f;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (Move())
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        Rotate();
    }

    private bool Move()
    {
        float vertical = Input.GetAxis("Vertical");
        move = transform.forward * vertical * speedMovement;
        playerRigidbody.MovePosition(playerRigidbody.position + move);
        playerAnimation.Move(vertical);
        return vertical != 0;
    }

    private void Rotate()
    {
        float horizontal = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, horizontal, 0) * speedRotation;
        playerRigidbody.MoveRotation(Quaternion.Euler(playerRigidbody.rotation.eulerAngles + rotation));
    }
}
