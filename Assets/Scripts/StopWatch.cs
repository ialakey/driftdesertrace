using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class Stopwatch : MonoBehaviour
{
    public Text timeText; 
    public float gameDuration = 60f; 

    private float elapsedTime = 0f;
    private bool isMoving = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (timeText == null)
        {
            Debug.LogError("TimeText is not assigned.");
        }
    }

    private void Update()
    {
        if (rb != null && rb.velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimeText();
        }

        if (elapsedTime >= gameDuration)
        {
            EndGame();
        }
    }

    private void UpdateTimeText()
    {
        int elapsedMinutes = Mathf.FloorToInt(elapsedTime / 60f);
        int elapsedSeconds = Mathf.FloorToInt(elapsedTime % 60f);
        float remainingTime = Mathf.Max(gameDuration - elapsedTime, 0f);
        int remainingMinutes = Mathf.FloorToInt(remainingTime / 60f);
        int remainingSeconds = Mathf.FloorToInt(remainingTime % 60f);

        timeText.text = string.Format("Elapsed: {0:D2}:{1:D2}\nRemaining: {2:D2}:{3:D2}",
            elapsedMinutes, elapsedSeconds, remainingMinutes, remainingSeconds);
    }

    private void EndGame()
    {
        Debug.Log("Game Over!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
