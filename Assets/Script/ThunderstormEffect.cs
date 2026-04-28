using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ThunderstormEffect : MonoBehaviour
{
    [Header("UI Flash")]
    public Image lightningFlash;

    [Header("Audio")]
    public AudioSource thunderAudio;

    [Header("Lightning Settings")]
    public float minDelay = 4f;
    public float maxDelay = 9f;
    public float flashAlpha = 0.85f;
    public float flashTime = 0.08f;
    public float thunderDelay = 0.25f;

    private void Start()
    {
        SetFlashAlpha(0f);
        StartCoroutine(LightningLoop());
    }

    private IEnumerator LightningLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            yield return StartCoroutine(Flash());

            yield return new WaitForSeconds(thunderDelay);

            if (thunderAudio != null)
            {
                thunderAudio.Play();
            }
        }
    }

    private IEnumerator Flash()
    {
        // First strong flash
        SetFlashAlpha(flashAlpha);
        yield return new WaitForSeconds(flashTime);

        SetFlashAlpha(0f);
        yield return new WaitForSeconds(0.05f);

        // Second weaker flash, makes it feel more natural
        SetFlashAlpha(flashAlpha * 0.45f);
        yield return new WaitForSeconds(flashTime);

        SetFlashAlpha(0f);
    }

    private void SetFlashAlpha(float alpha)
    {
        if (lightningFlash == null)
        {
            return;
        }

        Color color = lightningFlash.color;
        color.a = alpha;
        lightningFlash.color = color;
    }
}