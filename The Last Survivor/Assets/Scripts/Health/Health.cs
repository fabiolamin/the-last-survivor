using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float value = 100;
    public float Value
    {
        get {return value;}

        private set {this.value = value;}
    }

    public void Change(float amount)
    {
        value += amount;
    }
}
