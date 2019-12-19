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
        Value = value;
    }
}
