using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideController : MonoBehaviour
{
    PlayerController Player;

    private const string ENEMY_TAG = "Enemy";

    private void Start()
    {
        Player = gameObject.GetComponentInParent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsEnemyCollision(collision))
        {
            Player.Die();
        }
    }

    private bool IsEnemyCollision(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        return other.CompareTag(ENEMY_TAG);
    }

}
