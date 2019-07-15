using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float LoudRange;
    [SerializeField] float SilentRange;
    [SerializeField] float SightRange;
    [SerializeField] AttackTemplate attack;
    [SerializeField] Transform attackSource;
    [SerializeField] float ReloadSpeed;
    private float lastShot;
    [SerializeField] AIMovement idleMovement;
    [SerializeField] AIMovement awareMovement;

    private GameObject Player;
    private Collider2D collider;
    // Start is called before the first frame update
    private void Start()
    {
            
    }

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool doesSeePlayer = false;
        bool doesHearPlayer = false;

        // Check
        float dist = Vector3.Distance(Player.transform.position, transform.position);

        //Can see \ hear player (depends of the facing (scale.x)
        if(dist <= SightRange &&
            ((transform.localScale.x > 0 && transform.position.x < Player.transform.position.x) ||
            (transform.localScale.x < 0 && transform.position.x > Player.transform.position.x))
            )
        {
            collider.enabled = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Player.transform.position - transform.position);
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(Player.gameObject))
                {
                    doesSeePlayer = true;
                }
            }
            collider.enabled = true;
        }

        if (doesSeePlayer && lastShot + ReloadSpeed <= Time.time)
        {
            // Attack
            lastShot = Time.time;
            attack.PerformAttack(attackSource, Player.transform.position);
        }
        else if (doesHearPlayer)
        {
            // Move to position
            if(awareMovement!=null)
                awareMovement.ExecuteMove(this);
        }
        else
        {
            // Idle
            if (awareMovement != null)
                idleMovement.ExecuteMove(this);
        }
    }
}
