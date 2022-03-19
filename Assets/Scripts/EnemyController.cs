using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isBeingDestroyed = false;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        animator.SetBool("IsBeingDestroyed", isBeingDestroyed);
    }
}
