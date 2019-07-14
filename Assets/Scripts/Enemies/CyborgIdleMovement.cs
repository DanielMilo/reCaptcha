using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgIdleMovement : AIMovement
{
    public float MovmentSpeed;
    public float MinWalkTime;
    public float MaxWalkTime;
    public override void ExecuteMove(EnemyBehaviour me)
    {
        /*
        var m = new MonoBehaviour();
        m.Invoke("Walk", Random.Range(MinWalkTime, MaxWalkTime));
        */
    }

    public void Walk(EnemyBehaviour me)
    {
        // wander
        /*
        var randDir = Random.Range(0, 2);
        if (randDir == 1)
        {
            me.GetComponent<Rigidbody2D>().velocity = Vector2.right * MovmentSpeed * Time.deltaTime;
        }
        else
        {
            me.GetComponent<Rigidbody2D>().velocity = Vector2.right * MovmentSpeed * Time.deltaTime;
        }*/
    }
}
