using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stopwatch : MonoBehaviour
{
    public Text timeText;
    public float gameDuration = 28800f;

    private float elapsedTime = 0f;

    private void Start()
    {
        Cursor.visible = false;

        if (timeText == null)
        {
            Debug.LogError("TimeText is not assigned.");
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimeText();

        if (elapsedTime >= gameDuration)
        {
            EndGame();
        }
    }

    private void UpdateTimeText()
    {
        int elapsedHours = Mathf.FloorToInt(elapsedTime / 3600f);
        int elapsedMinutes = Mathf.FloorToInt((elapsedTime % 3600f) / 60f);
        int elapsedSeconds = Mathf.FloorToInt(elapsedTime % 60f);

        float remainingTime = Mathf.Max(gameDuration - elapsedTime, 0f);
        int remainingHours = Mathf.FloorToInt(remainingTime / 3600f);
        int remainingMinutes = Mathf.FloorToInt((remainingTime % 3600f) / 60f);
        int remainingSeconds = Mathf.FloorToInt(remainingTime % 60f);

        string elapsedText;
        string remainingText;

        if (elapsedHours > 0)
        {
            elapsedText = string.Format("{0:D2}H:{1:D2}M", elapsedHours, elapsedMinutes);
        }
        else
        {
            elapsedText = string.Format("{0:D2}M:{1:D2}S", elapsedMinutes, elapsedSeconds);
        }

        if (remainingHours > 0)
        {
            remainingText = string.Format("{0:D2}H:{1:D2}M", remainingHours, remainingMinutes);
        }
        else
        {
            remainingText = string.Format("{0:D2}M:{1:D2}S", remainingMinutes, remainingSeconds);
        }

        timeText.text = string.Format("Elapsed: {0}\nRemaining: {1}", elapsedText, remainingText);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }
}