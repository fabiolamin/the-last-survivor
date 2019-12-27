using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimateMovement(bool answer)
    {
        animator.SetBool("IsRunning", answer);
    }
}
