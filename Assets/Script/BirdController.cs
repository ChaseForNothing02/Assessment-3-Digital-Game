using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flapForce = 5f;

    private Rigidbody2D rb;
    private bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Flap();
        }
    }

    private void Flap()
    {
        rb.velocity = Vector2.up * flapForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Pipe"))
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        GameManager.Instance.GameOver();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreZone"))
        {
            ScoreManager.Instance.AddScore(1);
            Destroy(collision.gameObject);
        }
    }
}