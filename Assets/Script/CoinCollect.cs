using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public AudioClip coinSound;
    public int coinValue = 1;

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Coin touched by: " + collision.name + " Tag: " + collision.tag);

        if (collected) return;

        if (collision.CompareTag("Player"))
        {
            collected = true;

            Debug.Log("Player collected coin.");

            if (coinSound != null)
            {
                Debug.Log("Playing coin sound.");
                AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position, 1f);
            }
            else
            {
                Debug.LogWarning("Coin sound is missing.");
            }

            // 如果你原本有加金币数量的代码，放在这里
            // CoinManager.Instance.AddCoin(coinValue);

            Destroy(gameObject);
        }
    }
}