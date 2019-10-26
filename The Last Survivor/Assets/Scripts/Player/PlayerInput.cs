using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 GetHorizontalAndVerticalKeys()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            return -transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            return transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            return -transform.right;
        }

        return Vector3.zero;
    }
}
