using UnityEngine;

public class Ammo : MonoBehaviour
{
    private UIStatus UIStatus;
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
        UIStatus = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIStatus>();
    }

    public void Change(int value)
    {
        amount += value;
        amount = Mathf.Clamp(amount, 0, auxiliaryAmount);
        UIStatus.HasChanged = true;
    }
}
