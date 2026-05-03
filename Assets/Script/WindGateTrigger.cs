using UnityEngine;

public class WindGateTrigger : MonoBehaviour
{
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTriggered) return;

        if (collision.CompareTag("Player"))
        {
            hasTriggered = true;

            WindTunnelManager windManager = FindObjectOfType<WindTunnelManager>();

            if (windManager != null)
            {
                windManager.AddGatePassed();
            }
        }
    }
}