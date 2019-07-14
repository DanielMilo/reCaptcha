using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackTemplate : ScriptableObject
{
    public float Interval;
    public float Damage;

    public virtual void PerformAttack(Vector3 target)
    {
        Debug.Log("empty attack!");
    }
}
