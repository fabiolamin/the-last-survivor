using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
        GetComponent<UIStatus>().IsScenePaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<UIStatus>().IsScenePaused = false;
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
