using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttack", menuName = "ScriptableObjects/RangedAttack", order = 1)]
public class RangedAttack : AttackTemplate
{
    public float maxRange;
    public float projectileSpeed;
    public GameObject Projectile;

    public override void PerformAttack(Transform source, Vector3 target)
    {
        Debug.DrawLine(source.position, target, new Color(200, 0, 200), 0.6f);
        Debug.Log("RangedAttack::PerformAttack Drawing Ray");

        GameObject newProjectile = Instantiate(Projectile, source.position, source.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce((target - source.position).normalized * projectileSpeed);
    }
}
