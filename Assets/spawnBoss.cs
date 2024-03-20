using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnBoss : MonoBehaviour
{
    public List<GameObject> enemyList; // List để lưu trữ các enemy
    public GameObject spawnPoint1; // Vị trí spawn 1
    public GameObject SpawnRandomBoss(int total, int random)
    {
        GameObject randomEnemy = enemyList[random];
        for (int i = 0; i < total; i++)
        {
            Instantiate(randomEnemy, spawnPoint1.transform.position, Quaternion.identity);
        }
        return randomEnemy;
    }
}
