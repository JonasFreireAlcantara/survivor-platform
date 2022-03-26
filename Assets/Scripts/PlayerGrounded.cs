using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour
{
    PlayerController Player;

    private const string ENEMY_TAG = "Enemy";

    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Player.isJumping = false;
        }

        if (IsEnemyCollision(collision))
        {
            DestroyEnemy(collision.gameObject);
            Player.Jump();
        }
    }

    private void DestroyEnemy(GameObject gameObject)
    {
        Player.IncreaseScoreByDestroyingEnemy();

        EnemyController enemyController = gameObject.GetComponent<EnemyController>();
        enemyController.isBeingDestroyed = true;
        Destroy(gameObject, 0.6f);
    }

    private bool IsEnemyCollision(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        return other.CompareTag(ENEMY_TAG) && !Player.isDying;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Player.isJumping = true;
        }
    }
}
