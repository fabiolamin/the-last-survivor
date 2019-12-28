using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Move(float value)
    {
        animator.SetBool("IsIdle", value == 0);
        animator.SetFloat("Running", value);
    }
}
