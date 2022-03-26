using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float sprint = 1f;
    public float jumpForce;
    public bool isJumping;
    public bool isDying;
    public int lifes = 4;

    public Animator animator;
    public Text scoreTextElement;

    private Rigidbody2D rigidBody2D;
    private Vector3 movement;
    private PlayerSpawner playerSpawner;
    private EnemySpawner enemySpawner;

    private int score = 0;

    private bool faceRight = true;
    private const int RIGHT_INPUT = 1;
    private const int LEFT_INPUT = -1;
    private const string ENEMY_TAG = "Enemy";

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSpawner = GetComponent<PlayerSpawner>();
        enemySpawner = FindObjectOfType<EnemySpawner>();

        playerSpawner.SpawnDiamonds(lifes);
    }

    private void Update()
    {
        UpdateScore();
        UpdateSprint();

        if (CanMove())
        {
            Move();
        }

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
        animator.SetBool("IsDying", isDying);
    }

    private void Move()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += movement * Time.fixedDeltaTime * speed * sprint;
    }

    private void Flip()
    {
        faceRight = !faceRight;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private bool CanMove()
    {
        return !isDying;
    }

    private bool MustFlip()
    {
        return (faceRight && movement.x == PlayerController.LEFT_INPUT) || (!faceRight && movement.x == PlayerController.RIGHT_INPUT);
    }

    private bool MustJump()
    {
        return Input.GetButtonDown("Jump") && !isJumping && !isDying;
    }

    public void Jump()
    {
        rigidBody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    public void Die()
    {
        isJumping = false;
        isDying = true;
        playerSpawner.Respawn();
    }

    public void UpdateSprint()
    {
        if (Input.GetKey(KeyCode.R))
        {
            sprint = 3f;
        }
        else
        {
            sprint = 1f;
        }
    }

    public void UpdateScore()
    {
        scoreTextElement.text = string.Format("{0,7:D7}", score);
    }

    public void IncreaseScoreByDestroyingEnemy()
    {
        score += 200;
        enemySpawner.numberOfEnemiesToBeSpawned = (score / 1000) + 2;
    }

    public void RestoreStatesAfterRespawn()
    {
        isDying = false;
    }
}
