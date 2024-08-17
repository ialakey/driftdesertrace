using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Steamworks;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Button resumeButton;
    public Button changeCarButton;
    public Button quitButton;

    private bool _isStatsRecieved;
    private bool _isAchievementStatusUpdate;

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
        UnlockAchievement();

        SceneManager.LoadScene("Menu");
    }

    private void RequestStats()
    {
        _isStatsRecieved = SteamUserStats.RequestCurrentStats();
        Debug.Log($"RequestCurrentStats: {_isStatsRecieved}");
    }

    private void SetAchievement(string achName)
    {
        bool result = SteamUserStats.SetAchievement(achName);
        Debug.Log($"SetAchievement({achName}): {result}");
        _isAchievementStatusUpdate = SteamUserStats.StoreStats();
        Debug.Log($"StoreStats: {_isAchievementStatusUpdate}");
    }

    public void UnlockAchievement()
    {
        RequestStats();

        SetAchievement("NEW_ACHIEVEMENT_0");
        SetAchievement("NEW_ACHIEVEMENT_1");
        SetAchievement("NEW_ACHIEVEMENT_2");
        SetAchievement("NEW_ACHIEVEMENT_3");
        SetAchievement("NEW_ACHIEVEMENT_4");
        SetAchievement("NEW_ACHIEVEMENT_5");
        SetAchievement("NEW_ACHIEVEMENT_6");
        SetAchievement("NEW_ACHIEVEMENT_7");
        SetAchievement("NEW_ACHIEVEMENT_8");
        SetAchievement("NEW_ACHIEVEMENT_9");

        SetAchievement("NEW_ACHIEVEMENT_A");
        SetAchievement("NEW_ACHIEVEMENT_B");
        SetAchievement("NEW_ACHIEVEMENT_C");
        SetAchievement("NEW_ACHIEVEMENT_D");
        SetAchievement("NEW_ACHIEVEMENT_E");
        SetAchievement("NEW_ACHIEVEMENT_F");
        SetAchievement("NEW_ACHIEVEMENT_G");
        SetAchievement("NEW_ACHIEVEMENT_H");
        SetAchievement("NEW_ACHIEVEMENT_I");
        SetAchievement("NEW_ACHIEVEMENT_J");
        SetAchievement("NEW_ACHIEVEMENT_K");
        SetAchievement("NEW_ACHIEVEMENT_L");
        SetAchievement("NEW_ACHIEVEMENT_M");
        SetAchievement("NEW_ACHIEVEMENT_N");
        SetAchievement("NEW_ACHIEVEMENT_O");
        SetAchievement("NEW_ACHIEVEMENT_P");
        SetAchievement("NEW_ACHIEVEMENT_Q");
        SetAchievement("NEW_ACHIEVEMENT_R");
        SetAchievement("NEW_ACHIEVEMENT_S");
        SetAchievement("NEW_ACHIEVEMENT_T");
        SetAchievement("NEW_ACHIEVEMENT_U");
        SetAchievement("NEW_ACHIEVEMENT_V");
        SetAchievement("NEW_ACHIEVEMENT_W");
        SetAchievement("NEW_ACHIEVEMENT_X");
        SetAchievement("NEW_ACHIEVEMENT_Y");
        SetAchievement("NEW_ACHIEVEMENT_Z");
    }
}