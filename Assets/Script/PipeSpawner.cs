using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject coinPrefab;

    public float spawnInterval = 3f;

    public float minY = -1.5f;
    public float maxY = 1.5f;

    public float coinXOffset = 0f;
    public float coinYOffsetRange = 0.3f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPipeAndCoin();
            timer = 0f;
        }
    }

    private void SpawnPipeAndCoin()
    {
        float pipeRandomY = Random.Range(minY, maxY);

        Vector3 pipeSpawnPosition = new Vector3(transform.position.x, pipeRandomY, 0f);
        Instantiate(pipePrefab, pipeSpawnPosition, Quaternion.identity);

        if (coinPrefab != null)
        {
            float coinRandomOffsetY = Random.Range(-coinYOffsetRange, coinYOffsetRange);

            Vector3 coinSpawnPosition = new Vector3(
                transform.position.x + coinXOffset,
                pipeRandomY + coinRandomOffsetY,
                0f
            );

            Instantiate(coinPrefab, coinSpawnPosition, Quaternion.identity);
        }
    }
}