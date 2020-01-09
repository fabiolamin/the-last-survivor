using UnityEngine.UI;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField]
    private Text highRoundNumber;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private GameObject credits;
    [SerializeField]
    private GameObject backButton;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("highround") == 0)
        {
            PlayerPrefs.SetInt("highround", 1);
        }

        ShowHighRound();
    }

    private void ShowHighRound()
    {
        highRoundNumber.text = PlayerPrefs.GetInt("highround").ToString();
    }

    public void EnableTutorial()
    {
        DisableMenu();
        tutorial.SetActive(true);
    }

    public void EnableCredits()
    {
        DisableMenu();
        credits.SetActive(true);
    }

    private void DisableMenu()
    {
        menu.SetActive(false);
        backButton.SetActive(true);
    }

    public void EnableMenu()
    {
        tutorial.SetActive(false);
        credits.SetActive(false);
        menu.SetActive(true);
        backButton.SetActive(false);
    }
}
