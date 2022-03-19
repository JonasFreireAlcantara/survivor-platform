using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour
{
    PlayerController Player;

    // Start is called before the first frame update
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
            GameObject enemyGameObject = collision.gameObject;
            EnemyController enemyController = enemyGameObject.GetComponent<EnemyController>();
            enemyController.isBeingDestroyed = true;
            Destroy(enemyGameObject, 0.6f);

            Player.Jump();
        }
    }

    private bool IsEnemyCollision(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        return other.CompareTag("Enemy");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Player.isJumping = true;
        }
    }
}
