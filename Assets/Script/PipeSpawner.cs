using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f;
    public float minY = -1.5f;
    public float maxY = 1.5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 1f, spawnInterval);
    }

    private void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);

        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}