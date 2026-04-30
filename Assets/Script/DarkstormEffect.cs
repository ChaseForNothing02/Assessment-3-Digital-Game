using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DarkStormEffect : MonoBehaviour
{
    [Header("Darkness Overlay")]
    public Image darknessOverlay;

    [Header("Thunder Audio")]
    public AudioSource thunderAudio;

    [Header("Timing")]
    public float lightningInterval = 3f;
    public float thunderDelay = 0.2f;

    [Header("Visibility")]
    [Range(0f, 1f)]
    public float normalDarkAlpha = 0.92f;

    [Range(0f, 1f)]
    public float lightningDarkAlpha = 0.15f;

    public float visibleDuration = 0.8f;
    public float fadeBackDuration = 0.4f;

    private bool stormStopped = false;

    private void Start()
    {
        stormStopped = false;

        if (darknessOverlay != null)
        {
            darknessOverlay.gameObject.SetActive(true);
        }

        SetDarknessAlpha(normalDarkAlpha);
        StartCoroutine(StartStormSequence());
    }

    private IEnumerator StartStormSequence()
    {
        yield return new WaitForSeconds(0.2f);

        if (stormStopped)
        {
            yield break;
        }

        yield return StartCoroutine(LightningFlash());

        if (stormStopped)
        {
            yield break;
        }

        if (thunderAudio != null)
        {
            yield return new WaitForSeconds(thunderDelay);
            thunderAudio.Play();
        }

        yield return StartCoroutine(LightningLoop());
    }

    private IEnumerator LightningLoop()
    {
        while (!stormStopped)
        {
            yield return new WaitForSeconds(lightningInterval);

            if (stormStopped)
            {
                yield break;
            }

            yield return StartCoroutine(LightningFlash());

            if (stormStopped)
            {
                yield break;
            }

            if (thunderAudio != null)
            {
                yield return new WaitForSeconds(thunderDelay);
                thunderAudio.Play();
            }
        }
    }

    private IEnumerator LightningFlash()
    {
        if (stormStopped)
        {
            yield break;
        }

        SetDarknessAlpha(0.05f);
        yield return new WaitForSeconds(0.08f);

        if (stormStopped)
        {
            yield break;
        }

        SetDarknessAlpha(normalDarkAlpha);
        yield return new WaitForSeconds(0.05f);

        if (stormStopped)
        {
            yield break;
        }

        SetDarknessAlpha(lightningDarkAlpha);
        yield return new WaitForSeconds(visibleDuration);

        float timer = 0f;

        while (timer < fadeBackDuration)
        {
            if (stormStopped)
            {
                yield break;
            }

            timer += Time.deltaTime;
            float t = timer / fadeBackDuration;

            float currentAlpha = Mathf.Lerp(lightningDarkAlpha, normalDarkAlpha, t);
            SetDarknessAlpha(currentAlpha);

            yield return null;
        }

        if (!stormStopped)
        {
            SetDarknessAlpha(normalDarkAlpha);
        }
    }

    public void StopStormAndShowScreen()
    {
        stormStopped = true;

        StopAllCoroutines();

        SetDarknessAlpha(0f);

        if (darknessOverlay != null)
        {
            darknessOverlay.gameObject.SetActive(false);
        }

        if (thunderAudio != null)
        {
            thunderAudio.Stop();
        }
    }

    private void SetDarknessAlpha(float alpha)
    {
        if (darknessOverlay == null)
        {
            return;
        }

        Color color = darknessOverlay.color;
        color.a = alpha;
        darknessOverlay.color = color;
    }
}