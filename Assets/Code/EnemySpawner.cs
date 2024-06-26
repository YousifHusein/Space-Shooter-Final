using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    private bool isReady = true;
    private bool shot = false;

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            SpawnEnemy();
            shot = true;
            isReady = false;
        }
        else if (shot == true && isReady == false)
        {
            shot = false;
            StartCoroutine(UpdateTimer());
        }
    }

    private IEnumerator UpdateTimer()
    {
        yield return new WaitForSeconds(3f);
        isReady = true;
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-8f, 8f) + GameObject.Find("/Player/Spawner").transform.position.x, Random.Range(-4f, 4f) + GameObject.Find("/Player/Spawner").transform.position.y);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
