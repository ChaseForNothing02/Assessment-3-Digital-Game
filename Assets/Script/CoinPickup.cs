using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;
    public float moveSpeed = 2f;

    private void Update()
    {
        // Coin 跟 Pipe 一样往左移动
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // 超出屏幕后删除
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.AddCoin(coinValue);
            }

            Destroy(gameObject);
        }
    }
}