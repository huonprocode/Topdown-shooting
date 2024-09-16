using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwan : MonoBehaviour
{
    [SerializeField] GameObject pfEnemy, player;
    [SerializeField] float spawnRate = 2f, spawnRadius = 4.0f;

    private float spawnTimer = 0;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            SpawnEnemy();
            spawnTimer = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(player.transform.position, spawnRadius);  
    }
    void SpawnEnemy()
    {
        Vector2 randomPos = (Vector2) player.transform.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(pfEnemy, randomPos, Quaternion.identity);
    }
}
