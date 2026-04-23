using UnityEngine;

public class PipeMover : MonoBehaviour
{
    public float moveSpeed = 2f;

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}