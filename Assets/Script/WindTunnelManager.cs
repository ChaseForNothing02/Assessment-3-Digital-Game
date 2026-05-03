using UnityEngine;
using TMPro;

public class WindTunnelManager : MonoBehaviour
{
    public enum WindState
    {
        Calm,
        WindUp,
        WindDown,
        Alternating,
        Win
    }

    [Header("References")]
    public BirdWindReceiver birdWind;
    public TMP_Text windText;
    public TMP_Text progressText;
    public GameObject winPanel;

    [Header("Wind Force")]
    public float windUpForce = 4f;
    public float windDownForce = -3.5f;

    [Header("Level Progress")]
    public int gatesPassed = 0;
    public int winGateCount = 18;

    [Header("Alternating Wind")]
    public float alternateInterval = 3f;

    private WindState currentState = WindState.Calm;
    private float alternateTimer = 0f;
    private bool alternatingUp = true;
    private bool hasWon = false;

    private void Start()
    {
        Time.timeScale = 1f;

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        ApplyWindState(WindState.Calm);
        UpdateProgressText();
    }

    private void Update()
    {
        if (hasWon) return;

        if (currentState == WindState.Alternating)
        {
            alternateTimer += Time.deltaTime;

            if (alternateTimer >= alternateInterval)
            {
                alternateTimer = 0f;
                alternatingUp = !alternatingUp;

                if (alternatingUp)
                {
                    SetWindUp();
                }
                else
                {
                    SetWindDown();
                }
            }
        }
    }

    public void AddGatePassed()
    {
        if (hasWon) return;

        gatesPassed++;
        UpdateProgressText();
        UpdateLevelStage();

        if (gatesPassed >= winGateCount)
        {
            WinLevel();
        }
    }

    private void UpdateLevelStage()
    {
        if (gatesPassed < 3)
        {
            ApplyWindState(WindState.Calm);
        }
        else if (gatesPassed < 6)
        {
            ApplyWindState(WindState.WindUp);
        }
        else if (gatesPassed < 8)
        {
            ApplyWindState(WindState.Calm);
        }
        else if (gatesPassed < 11)
        {
            ApplyWindState(WindState.WindDown);
        }
        else if (gatesPassed < 13)
        {
            ApplyWindState(WindState.Calm);
        }
        else
        {
            ApplyWindState(WindState.Alternating);
        }
    }

    private void ApplyWindState(WindState newState)
    {
        if (currentState == newState) return;

        currentState = newState;
        alternateTimer = 0f;

        switch (currentState)
        {
            case WindState.Calm:
                SetCalm();
                break;

            case WindState.WindUp:
                SetWindUp();
                break;

            case WindState.WindDown:
                SetWindDown();
                break;

            case WindState.Alternating:
                alternatingUp = true;
                SetWindUp();
                break;
        }
    }

    private void SetCalm()
    {
        if (birdWind != null)
        {
            birdWind.SetWind(0f);
        }

        if (windText != null)
        {
            windText.text = "Calm";
        }
    }

    private void SetWindUp()
    {
        if (birdWind != null)
        {
            birdWind.SetWind(windUpForce);
        }

        if (windText != null)
        {
            windText.text = "Wind Up ↑";
        }
    }

    private void SetWindDown()
    {
        if (birdWind != null)
        {
            birdWind.SetWind(windDownForce);
        }

        if (windText != null)
        {
            windText.text = "Wind Down ↓";
        }
    }

    private void UpdateProgressText()
    {
        if (progressText != null)
        {
            progressText.text = "Gates: " + gatesPassed + " / " + winGateCount;
        }
    }

    private void WinLevel()
    {
        hasWon = true;
        currentState = WindState.Win;

        if (birdWind != null)
        {
            birdWind.SetWind(0f);
        }

        if (windText != null)
        {
            windText.text = "Escaped!";
        }

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}