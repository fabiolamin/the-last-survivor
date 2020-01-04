using UnityEngine;

public class Health : MonoBehaviour
{
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
    }

    private void Update()
    {
        if (amount <= 0)
        {
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
    }

    public void Restart()
    {
        amount = auxiliaryAmount;
    }
}
