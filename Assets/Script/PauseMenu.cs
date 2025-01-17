using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool pause = false;
    public GameObject MenupauseUI;
    // Update is called once per frame
    public GameObject SettingsWindow;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pause)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused() 
    {
        MenupauseUI.SetActive(true);
        Time.timeScale = 0;
        pause = true;
    }

    public void Resume() 
    {
        MenupauseUI.SetActive(false);
        Time.timeScale = 1;
        pause = false;
    }

    public void OpenSettingsWindow()
    {
        SettingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        SettingsWindow.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
