using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public List<GameObject> enemyList; // List để lưu trữ các enemy
    public GameObject spawnPoint1; // Vị trí spawn 1
    public GameObject spawnPoint2; // Vị trí spawn 2

    private bool isBossSpawned = false; // Biến kiểm tra xem boss đã được sinh ra hay chưa

    // Function để random enemy từ List
    private GameObject RandomEnemy()
    {
        int randomIndex = Random.Range(0, enemyList.Count);
        return enemyList[randomIndex];
    }

    // Function để random vị trí spawn
    private Transform RandomSpawnPoint()
    {
        int randomPoint = Random.Range(0, 2);
        if (randomPoint == 0)
        {
            return spawnPoint1.transform;
        }
        else
        {
            return spawnPoint2.transform;
        }
    }

    // Function để spawn enemy
    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            if (!isBossSpawned) // Kiểm tra xem boss đã được sinh ra hay chưa
            {
                GameObject randomEnemy = RandomEnemy();
                Transform randomSpawnPoint = RandomSpawnPoint();
                Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);
                isBossSpawned = true; // Đánh dấu boss đã được sinh ra
            }

            yield return new WaitForSeconds(2); // Wait for 2 seconds
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }
}