using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public float spawnInterval = 2f;
    public float minY = -2f;
    public float maxY = 3f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    private void SpawnCoin()
    {
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);

        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}