using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField]
    private RoundController roundController;
    [SerializeField]
    private Text roundNumber;
    [SerializeField]
    private GameObject status;
    [SerializeField]
    private Health health;
    [SerializeField]
    private Text healthAmount;
    [SerializeField]
    private Ammo ammo;
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
    public bool HasChanged { get; set; }

    private void Awake()
    {
        HasChanged = true;
    }

    private void Update()
    {
        if (HasChanged)
        {
            SetStatusText();
            HasChanged = false;
        }

        ControlPause();
    }

    private void SetStatusText()
    {
        roundNumber.text = roundController.RoundNumber.ToString();
        healthAmount.text = health.Amount.ToString();
        ammoAmount.text = ammo.Amount.ToString();
    }

    private void ControlPause()
    {
        pauseMenu.SetActive(IsScenePaused);
        defaultButtons.SetActive(IsScenePaused);
    }

    public void SetGameOver()
    {
        gameOver.SetActive(true);
        pauseButton.SetActive(false);
        defaultButtons.SetActive(true);
        status.SetActive(false);
    }
}
