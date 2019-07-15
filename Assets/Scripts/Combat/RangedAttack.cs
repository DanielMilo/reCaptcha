using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttack", menuName = "ScriptableObjects/RangedAttack", order = 1)]
public class RangedAttack : AttackTemplate
{
    public float maxRange;
    public GameObject Projectile;

    public override void PerformAttack(Vector3 target)
    {
        Debug.Log("RangedAttack::PerformAttack Pew");

    }
}
