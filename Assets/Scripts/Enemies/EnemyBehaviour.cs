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

    private GameObject Player;

    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        bool doesNoticePlayer = false;

        // Check 



        if (doesNoticePlayer)
        {
            // Attack
        }
        else
        {
            // Idle
        }
    }
}
