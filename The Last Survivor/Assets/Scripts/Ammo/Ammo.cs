using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int auxiliaryAmount;
    [SerializeField]
    private int amount = 50;
    public int Amount
    {
        get { return amount; }
        private set { amount = value; }
    }

    private void Awake()
    {
        auxiliaryAmount = amount;
    }

    public void Change(int value)
    {
        amount += value;
        amount = Mathf.Clamp(amount, 0, auxiliaryAmount);
    }
}
