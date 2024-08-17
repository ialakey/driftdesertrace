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

        if (result)
        {
            _isAchievementStatusUpdate = SteamUserStats.StoreStats();
        }
        else
        {
            Debug.LogError($"Failed to set achievement: {achName}");
        }
    }

    public void UnlockAchievement()
    {
        RequestStats();

        string[] achievementIDs = {
        "NEW_ACHIEVEMENT_0", "NEW_ACHIEVEMENT_1", "NEW_ACHIEVEMENT_2",
        "NEW_ACHIEVEMENT_3", "NEW_ACHIEVEMENT_4", "NEW_ACHIEVEMENT_5",
        "NEW_ACHIEVEMENT_6", "NEW_ACHIEVEMENT_7", "NEW_ACHIEVEMENT_8",
        "NEW_ACHIEVEMENT_9", "NEW_ACHIEVEMENT_A", "NEW_ACHIEVEMENT_B",
        "NEW_ACHIEVEMENT_C", "NEW_ACHIEVEMENT_D", "NEW_ACHIEVEMENT_E",
        "NEW_ACHIEVEMENT_F", "NEW_ACHIEVEMENT_G", "NEW_ACHIEVEMENT_H",
        "NEW_ACHIEVEMENT_I", "NEW_ACHIEVEMENT_J", "NEW_ACHIEVEMENT_K",
        "NEW_ACHIEVEMENT_L", "NEW_ACHIEVEMENT_M", "NEW_ACHIEVEMENT_N",
        "NEW_ACHIEVEMENT_O", "NEW_ACHIEVEMENT_P", "NEW_ACHIEVEMENT_Q",
        "NEW_ACHIEVEMENT_R", "NEW_ACHIEVEMENT_S", "NEW_ACHIEVEMENT_T",
        "NEW_ACHIEVEMENT_U", "NEW_ACHIEVEMENT_V", "NEW_ACHIEVEMENT_W",
        "NEW_ACHIEVEMENT_X", "NEW_ACHIEVEMENT_Y", "NEW_ACHIEVEMENT_Z"
    };

        foreach (var achievementID in achievementIDs)
        {
            SetAchievement(achievementID);
        }

        _isAchievementStatusUpdate = SteamUserStats.StoreStats();
    }
}