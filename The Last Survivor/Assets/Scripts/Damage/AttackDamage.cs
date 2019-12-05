using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    [SerializeField]
    private float value = 10;

    public float Value 
    {
        get{ return value; }
        private set { this.value = value; }
    }
   
    public void Change(float amount)
    {
        Value += amount;
    }
}
