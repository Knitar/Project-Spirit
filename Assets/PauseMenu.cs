using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool pause = false;
    public GameObject MenupauseUI;
    // Update is called once per frame
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

    
}
