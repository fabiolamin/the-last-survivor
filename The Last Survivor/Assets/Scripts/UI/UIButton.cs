using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public bool IsScenePaused { get; private set; }
    public void Pause()
    {
        Time.timeScale = 0;
        IsScenePaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        IsScenePaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
