using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform playerTransform;
    public float spawnRadius = 10f;
    public int enemiesPerWave = 5;
    public float timeBetweenWaves = 5f;

    private int waveNumber = 0;
    private int enemiesSpawned = 0;
    private float nextWaveTime = 0f;

    public UIManager uiManager;

    private void Start()
    {
        {
            uiManager.UpdateWaveNumber(waveNumber);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextWaveTime)
        {
            StartCoroutine(SpawnWave());
            nextWaveTime = Time.time + timeBetweenWaves;
        }
        else
        {
            float timeRemaining = nextWaveTime - Time.time;
            if (uiManager != null)
            {
                uiManager.updateTimer(timeRemaining);
            }
        }
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        enemiesPerWave += waveNumber;
        uiManager.UpdateWaveNumber(waveNumber);
        enemiesSpawned = 0;

        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            enemiesSpawned++;
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = GetRandomPositionAroundPlayer();
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }

    Vector2 GetRandomPositionAroundPlayer()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)playerTransform.position + randomDirection * spawnRadius;
        return spawnPosition;
    }
}