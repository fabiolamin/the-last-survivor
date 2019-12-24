using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private int amount = 50;
    public int Amount
    {
        get{ return amount; }
        private set{ amount = value; }
    }

    private void Update()
    {
        if (amount <= 0)
        {
            //ToDo
        }
    }

    public void Change(int value)
    {
        amount += value;
    }
}
