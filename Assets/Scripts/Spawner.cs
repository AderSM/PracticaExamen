using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float initWait = 2f;

    private float currentWait;
    private void Awake()
    {
        currentWait = initWait;
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        currentWait -= 0.05f * Time.deltaTime;
        if (currentWait < 0.05f)
        {
            currentWait = 0.5f;
        }
    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            if (randomSpawnPoint.x > 0)
            {
                Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.Euler(0, 0, 90));
            }
            else if (randomSpawnPoint.x < 0)
            {
                Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.Euler(0, 0, -90));
            }
            else if (randomSpawnPoint.y > 0)
            {
                Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.Euler(0, 0, 180));
            }
            else
            {
                Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
            }
                yield return new WaitForSeconds(currentWait);
        }
    }
}
