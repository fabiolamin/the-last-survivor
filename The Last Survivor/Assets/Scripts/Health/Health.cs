using UnityEngine;

public class Health : MonoBehaviour
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

    public void ChangeHealth(int amount)
    {
        healthValue += amount;
    }
}
