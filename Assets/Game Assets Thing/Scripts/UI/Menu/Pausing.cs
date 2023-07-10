using UnityEngine;

public class Pausing : MonoBehaviour
{
    bool paused = true;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(paused);
        Time.timeScale = 0f;
        paused = !paused;
        AudioListener.volume = 0.5f;
    }

    public void UnPause()
    {
        pauseMenu.SetActive(paused);
        Time.timeScale = 1f;
        paused = !paused;
        AudioListener.volume = 1f;
    }
}
