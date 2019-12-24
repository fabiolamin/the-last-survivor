using UnityEngine;

public class Health : MonoBehaviour
{
    private float auxiliaryAmount;
    [SerializeField]
    private float amount = 100;
    public float Amount
    {
        get {return amount; }

        private set { amount = value;}
    }

    private void Awake()
    {
        auxiliaryAmount = Amount;
    }

    private void Update()
    {
        if(Amount <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Change(float value)
    {
        amount += value;
    }

    public void Restart()
    {
        Amount = auxiliaryAmount;
    }
}
