using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject settingWindow;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           if(PauseMenu.pause)
            {
                settingWindow.SetActive(false);
            }
            else
            {
                settingWindow.SetActive(true);
            }
        }
            if(!PauseMenu.pause)
            {
                settingWindow.SetActive(true);
            }
            else
            {
                settingWindow.SetActive(false);
            }
    }

}
