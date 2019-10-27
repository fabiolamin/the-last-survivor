using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    [SerializeField]
    private int value = 10;
    public int Value
    {
        get{ return value; }
        set{ this.value = value; }
    }
}
