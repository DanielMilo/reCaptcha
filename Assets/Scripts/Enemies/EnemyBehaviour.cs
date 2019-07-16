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

    [SerializeField] float projectileSpeed;
    [SerializeField] GameObject Projectile;

    // Laser
    LineRenderer laserLineRenderer;
    [SerializeField] float laserWidth = 0.3f;

    private GameObject Player;
    private Collider2D collider;
    // Start is called before the first frame update
    private void Start()
    {
        laserLineRenderer = GetComponent<LineRenderer>();
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
        Color purple = new Color(200, 0, 200);
        laserLineRenderer.startColor = purple;
        laserLineRenderer.endColor = purple;
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

        // while the enemy isnt reloading
        if (lastShot + ReloadSpeed <= Time.time)
        {
            // Check
            float dist = Vector3.Distance(Player.transform.position, transform.position);

            //Can see \ hear player (depends of the facing (scale.x)
            if (dist <= SightRange &&
                ((transform.localScale.x > 0 && transform.position.x < Player.transform.position.x) ||
                (transform.localScale.x < 0 && transform.position.x > Player.transform.position.x))
                )
            {
                collider.enabled = false;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Player.transform.position - transform.position);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.Equals(Player.gameObject))
                    {
                        doesSeePlayer = true;
                    }
                }
                collider.enabled = true;
            }

            if (doesSeePlayer)
            {
                laserLineRenderer.enabled = true;

                // Attack
                lastShot = Time.time;
                PerformAttack();
            }
            else if (doesHearPlayer)
            {
                laserLineRenderer.enabled = false;
                // Move to position
                if (awareMovement != null)
                    awareMovement.ExecuteMove(this);
            }
            else
            {
                laserLineRenderer.enabled = false;
                // Idle
                if (awareMovement != null)
                    idleMovement.ExecuteMove(this);
            }
        }
    }

    public void PerformAttack()
    {
        Debug.Log("RangedAttack::PerformAttack Drawing Ray");
        laserLineRenderer.SetPosition(0, attackSource.position);
        laserLineRenderer.SetPosition(1, Player.transform.position);
        target = Player.transform.position;
        Invoke("Fire", 0.6f);
    }

    // Acts as param for Fire
    private Vector3 target;
    public void Fire()
    {
        GameObject newProjectile = Instantiate(Projectile, attackSource.position, attackSource.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce((target - transform.position).normalized * projectileSpeed);
    }

}

