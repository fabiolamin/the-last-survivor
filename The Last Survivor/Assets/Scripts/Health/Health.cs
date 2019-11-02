using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int value = 100;
    public int Value
    {
        get {return value;}

        set {this.value = value;}
    }

    public void Change(int amount)
    {
        value += amount;
    }
}
