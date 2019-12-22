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

    public void Change(int value)
    {
        amount += value;
    }
}
