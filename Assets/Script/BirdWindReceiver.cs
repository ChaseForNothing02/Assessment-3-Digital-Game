using UnityEngine;

public class BirdWindReceiver : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Wind Settings")]
    public float windForceY = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (windForceY != 0f)
        {
            rb.AddForce(new Vector2(0f, windForceY), ForceMode2D.Force);
        }
    }

    public void SetWind(float newWindForce)
    {
        windForceY = newWindForce;
    }
}