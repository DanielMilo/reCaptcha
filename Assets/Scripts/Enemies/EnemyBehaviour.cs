using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float LoudRange;
    [SerializeField]
    private float SilentRange;
    [SerializeField]
    private float SightRange;
    [SerializeField]
    private AttackTemplate attack;

    private GameObject Player;

    // Start is called before the first frame update
    private void Start()
    {
            
    }

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        bool doesSeePlayer = false;
        bool doesHearPlayer = false;

        // Check
        float dist = Vector3.Distance(Player.transform.position, transform.position);

        //Can see \ hear player
        /*if (dist < SightRange || (Player.isLoud && dist < LoudRange) || (Player.isSilent && dist < SilentRange))
        {
            doesNoticePlayer = true;
        }
        else
        {
            doesNoticePlayer = false;
        }*/

        if (doesSeePlayer)
        {
            // Attack
            attack.PerformAttack(Player.transform.position);
        }
        else if (doesHearPlayer)
        {
            // Move to position
        }
        else
        {
            // Idle
        }
    }
}
