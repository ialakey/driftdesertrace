using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMain : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

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
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
