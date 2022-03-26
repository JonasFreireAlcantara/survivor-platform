using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject diamondGameObject;
    public float spawnDelay;
    
    private Stack<GameObject> diamonds;
    private Vector3 playerSpawnPosition = new Vector3(0, 1, 0);
    private PlayerController playerController;

    void Start()
    {
        diamonds = new Stack<GameObject>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void SpawnDiamonds(int lifeNumber)
    {
        for (int lifeOrder = 0; lifeOrder < lifeNumber; lifeOrder++)
        {
            SpawnDiamond(lifeOrder);
        }
    }

    public void SpawnDiamond(int lifeOrder)
    {
        float yPosition = 3.25f;
        float xPosition = 5.25f - (0.5f * lifeOrder);

        Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0);
        GameObject createdDiamond = Instantiate(diamondGameObject, spawnPosition, Quaternion.identity);

        diamonds.Push(createdDiamond);
    }

    public void DestroyOneDiamond()
    {
        GameObject diamondToBeDestroyed = diamonds.Pop();
        Destroy(diamondToBeDestroyed);
    }

    public void Respawn()
    {
        if (IsGameOver())
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(RespawnPlayerWithDelay());
        }
    }

    public bool IsGameOver()
    {
        return diamonds.Count == 0;
    }

    private IEnumerator RespawnPlayerWithDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        DestroyOneDiamond();
        playerController.transform.position = playerSpawnPosition;
        playerController.RestoreStatesAfterRespawn();
    }
}
