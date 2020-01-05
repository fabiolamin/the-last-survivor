using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    private UIButton UIButton;
    [SerializeField]
    private RoundController roundController;
    [SerializeField]
    private Health health;
    [SerializeField]
    private Ammo ammo;
    [SerializeField]
    private Text roundNumberText;
    [SerializeField]
    private Text healthAmountText;
    [SerializeField]
    private Text ammoAmountText;
    [SerializeField]
    private GameObject pauseMenu;

    private void Awake()
    {
        UIButton = GetComponent<UIButton>();
    }

    private void Update()
    {
        SetText();

        pauseMenu.SetActive(UIButton.IsScenePaused);
    }

    private void SetText()
    {
        roundNumberText.text = roundController.RoundNumber.ToString();
        healthAmountText.text = health.Amount.ToString();
        ammoAmountText.text = ammo.Amount.ToString();
    }
}
