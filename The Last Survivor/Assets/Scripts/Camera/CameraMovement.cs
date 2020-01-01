using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offSet;

    private void Awake()
    {
        offSet = transform.position - target.position;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + offSet.x, transform.position.y, target.position.z + offSet.z);
    }
}
