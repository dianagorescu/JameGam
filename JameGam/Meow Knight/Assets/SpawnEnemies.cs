using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Pathfinding;

public class SpawnEnemies : MonoBehaviour
{
    public Transform playerTarget;
    public GameObject enemyPrefab;
    bool spawning = false;
    float spawnTick = 5f;
    int positionSpawn = 1;

    // Update is called once per frame
    void Update()
    {
        if(!spawning)
        {
            spawning = true;
            Invoke("SpawnEnemy", spawnTick);
        } 
    }

    void SpawnEnemy()
    {
        Vector3 enemyOffset = new Vector3(positionSpawn*Random.Range(10, 20), 0, 0);
        positionSpawn *= -1;
        GameObject enemy = Instantiate(enemyPrefab, playerTarget.position + enemyOffset, playerTarget.rotation);
        enemy.GetComponent<AIDestinationSetter>().target = playerTarget;
        spawning = false;    
    }
}
