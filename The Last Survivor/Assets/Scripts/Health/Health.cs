using UnityEngine;

public class Health : MonoBehaviour
{
    private float auxiliaryValue;
    [SerializeField]
    private float value = 100;
    public float Value
    {
        get {return value;}

        private set {this.value = value;}
    }

    private void Awake()
    {
        auxiliaryValue = Value;
    }

    private void Update()
    {
        if(Value <=0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Change(float amount)
    {
        value += amount;
    }

    public void Restart()
    {
        Value = auxiliaryValue;
    }
}
