using UnityEngine;

public class PipeMover : MonoBehaviour
{
    public float baseMoveSpeed = 2f;
    public float destroyX = -10f;

    private void Update()
    {
        float multiplier = 1f;

        if (GameSpeedManager.Instance != null)
        {
            multiplier = GameSpeedManager.Instance.speedMultiplier;
        }

        transform.position += Vector3.left * baseMoveSpeed * multiplier * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}