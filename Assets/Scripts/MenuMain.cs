using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Steamworks;

public class MenuMain : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private bool _isStatsRecieved;
    private bool _isAchievementStatusUpdate;

    void Start()
    {
        Cursor.visible = true;
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);

        if (!SteamManager.Initialized)
        {
            Debug.LogError("Steam API не инициализирована");
            return;
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("RCC City (Car Selection with Load Next Scene)");
    }

    void QuitGame()
    {
        UnlockAchievement();

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
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
            "NEW_ACHIEVEMENT_RUS_1", "NEW_ACHIEVEMENT_RUS_2", "NEW_ACHIEVEMENT_RUS_3",
            "NEW_ACHIEVEMENT_RUS_4", "NEW_ACHIEVEMENT_RUS_5", "NEW_ACHIEVEMENT_RUS_6",
            "NEW_ACHIEVEMENT_RUS_7", "NEW_ACHIEVEMENT_RUS_8", "NEW_ACHIEVEMENT_RUS_9",
            "NEW_ACHIEVEMENT_RUS_10", "NEW_ACHIEVEMENT_RUS_11", "NEW_ACHIEVEMENT_RUS_12",
            "NEW_ACHIEVEMENT_RUS_13", "NEW_ACHIEVEMENT_RUS_14", "NEW_ACHIEVEMENT_RUS_15",
            "NEW_ACHIEVEMENT_RUS_16", "NEW_ACHIEVEMENT_RUS_17", "NEW_ACHIEVEMENT_RUS_18",
            "NEW_ACHIEVEMENT_RUS_19", "NEW_ACHIEVEMENT_RUS_20", "NEW_ACHIEVEMENT_RUS_21",
            "NEW_ACHIEVEMENT_RUS_22", "NEW_ACHIEVEMENT_RUS_23", "NEW_ACHIEVEMENT_RUS_24",
            "NEW_ACHIEVEMENT_RUS_25", "NEW_ACHIEVEMENT_RUS_26", "NEW_ACHIEVEMENT_RUS_27",
            "NEW_ACHIEVEMENT_RUS_28", "NEW_ACHIEVEMENT_RUS_29", "NEW_ACHIEVEMENT_RUS_30",
            "NEW_ACHIEVEMENT_RUS_31", "NEW_ACHIEVEMENT_RUS_32", "NEW_ACHIEVEMENT_RUS_33",
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13"
           };


        foreach (var achievementID in achievementIDs)
        {
            SetAchievement(achievementID);
        }

        _isAchievementStatusUpdate = SteamUserStats.StoreStats();
    }
}
