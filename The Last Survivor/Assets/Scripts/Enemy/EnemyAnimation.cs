using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    public bool IsAttacking { get; set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        IsAttacking = false;
    }

    private void Update()
    {
        animator.SetBool("IsAttacking", IsAttacking);
    }

}
