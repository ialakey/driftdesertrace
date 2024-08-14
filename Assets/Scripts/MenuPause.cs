using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Button resumeButton;
    public Button changeCarButton;
    public Button quitButton;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuPanel.SetActive(false);

        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
        changeCarButton.onClick.AddListener(ChangeCar);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
    }

    public void ChangeCar()
    {
        SceneManager.LoadScene("RCC City (Car Selection with Load Next Scene)");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}