using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField]
    private RoundController roundController;
    [SerializeField]
    private Health health;
    [SerializeField]
    private Ammo ammo;
    [SerializeField]
    private Text roundNumber;
    [SerializeField]
    private Text healthAmount;
    [SerializeField]
    private Text ammoAmount;
    [SerializeField]
    private GameObject defaultButtons;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameOver;
    public bool IsScenePaused { get; set; }
    public bool IsGameOver { get; set; }

    private void Update()
    {
        SetStatusText();

        pauseButton.SetActive(!IsGameOver);
        pauseMenu.SetActive(IsScenePaused);
        defaultButtons.SetActive(IsScenePaused || IsGameOver);
        gameOver.SetActive(IsGameOver);
    }

    private void SetStatusText()
    {
        roundNumber.text = roundController.RoundNumber.ToString();
        healthAmount.text = health.Amount.ToString();
        ammoAmount.text = ammo.Amount.ToString();
    }
}
