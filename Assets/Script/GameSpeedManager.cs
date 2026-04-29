using UnityEngine;

public class GameSpeedManager : MonoBehaviour
{
    public static GameSpeedManager Instance;

    public float speedMultiplier = 1f;
    public float increasePerSecond = 0.25f;
    public float maxMultiplier = 4f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        speedMultiplier += increasePerSecond * Time.deltaTime;

        if (speedMultiplier > maxMultiplier)
        {
            speedMultiplier = maxMultiplier;
        }
    }
}