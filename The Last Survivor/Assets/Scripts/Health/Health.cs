using UnityEngine;

public class Health : MonoBehaviour
{
    private RoundController roundController;
    private UIStatus UIStatus;
    private float auxiliaryAmount;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private float amount = 100;
    public float Amount
    {
        get { return amount; }

        private set { amount = value; }
    }

    private void Awake()
    {
        auxiliaryAmount = amount;
        UIStatus = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIStatus>();
        roundController = GameObject.FindGameObjectWithTag("RoundController").GetComponent<RoundController>();
    }

    private void Update()
    {
        if (amount <= 0)
        {
            if(gameObject.CompareTag("Enemy"))
            {
                roundController.DefeatedsEnemies++;
            }

            gameObject.SetActive(false);
        }
    }

    public void Change(float value)
    {
        amount += value;
        amount = Mathf.Clamp(amount, 0, auxiliaryAmount);

        if (value < 0)
        {
            particle.Play();
        }

        if(gameObject.CompareTag("Player"))
        {
            UIStatus.HasChanged = true;
        }
    }

    public void Restart()
    {
        amount = auxiliaryAmount;
    }
}
