using UnityEngine;

public class MainMenu : MonoBehaviour
{
    Pausing pause;
    public bool isSoundOn = true;
    Transitions transition;

    private void Start()
    {
        Time.timeScale = 1;
        pause = FindObjectOfType<Pausing>();
        transition = FindObjectOfType<Transitions>();
    }

    public void Play()
    {
        transition.LoadOtherScene(1);
        AudioListener.volume = 1f;
    }

    public void Resume()
    {
        pause.UnPause();
    }

    public void Quit()
    {
        Debug.Log("bruh");
        Application.Quit();
    } 

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        transition.LoadOtherScene(0);
    }

    public void VolChange()
    {
        if (isSoundOn)
        {
            AudioListener.volume = 0;
            isSoundOn = false;
        }
        else
        {
            AudioListener.volume = 1;
            isSoundOn = true;
        }
    }
}