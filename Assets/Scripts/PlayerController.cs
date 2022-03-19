using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isJumping;

    public Animator animator;

    private Rigidbody2D rigidBody2D;
    private Vector3 movement;

    private bool faceRight = true;

    private const int RIGHT_INPUT = 1;
    private const int LEFT_INPUT = -1;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();

        if (MustJump())
        {
            Jump();
        }

        if (MustFlip())
        {
            Flip();
        }

        Animate();
    }

    private void Animate() {
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
        animator.SetBool("IsJumping", isJumping);
    }

    private void Move()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += movement * Time.fixedDeltaTime * speed;
    }

    private void Flip()
    {
        faceRight = !faceRight;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private bool MustFlip()
    {
        return (faceRight && movement.x == PlayerController.LEFT_INPUT) || (!faceRight && movement.x == PlayerController.RIGHT_INPUT);
    }

    private bool MustJump()
    {
        return Input.GetButtonDown("Jump") && !isJumping;
    }

    public void Jump()
    {
        rigidBody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
}
