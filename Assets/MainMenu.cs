using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string LeveltoLoad;

    public GameObject settingWindow;

    public void StartGame()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }


    public void SettingsButton()
    {
        settingWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
