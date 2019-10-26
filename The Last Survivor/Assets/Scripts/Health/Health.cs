using UnityEngine;

public class Health
{
    [SerializeField]
    private int healthValue = 100;
    public int HealthValue
    {
        get { return healthValue; }

        set
        {
            healthValue = value;
        }
    }

    void ChangeHealth(int amount)
    {
        healthValue += amount;
    }
}
