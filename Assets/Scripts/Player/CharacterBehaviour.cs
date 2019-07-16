using Assets.Scripts.Environment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    // 3rd party script for smooth controls. is called in fixed update.
    private CharacterController controller;
    
    // transfer memory from update to fixed to handle input correctly
    private float movement;
    private bool jump = false;
    private bool crouch = false;

    [SerializeField] float WalkingSpeed = 5;

    [SerializeField] int MaxHealth = 3;
    private int currentHealth = 3;
    public Transform respawnCheckpoint;

    [SerializeField] public bool isRobotLegs;
    [SerializeField] public bool isRobotArms;
    [SerializeField] public bool isRobotBrain;

    public bool isCutscene = false;

    [SerializeField] GameObject Projectile;
    [SerializeField] Transform projectileSpawn;
    [SerializeField] Vector2 ProjectileForce;
    private Animator animator;

    [SerializeField] float ReloadTime;
    private float lastShot;

    [SerializeField] BoxCollider2D boxCollider;

    [SerializeField] int robotDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        controller.OnCrouchEvent.AddListener(OnCrouch);
        controller.OnLandEvent.AddListener(OnLand);
    }

    void OnCrouch(bool newCrouchState)
    {
        animator.SetBool("Crouching", newCrouchState);
    }

    void OnLand()
    {
        animator.SetTrigger("HitGround");
    }

    public void OnHit(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            // Death and respawn
            currentHealth = MaxHealth;
            transform.position = respawnCheckpoint.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement = 0;
        if (!isCutscene)
        {
            movement = Input.GetAxis("Horizontal") * WalkingSpeed;

            if (movement != 0)
            {
                var walkingAudio = this.GetComponents<AudioSource>()[0];
                if (!walkingAudio.isPlaying)
                {
                    walkingAudio.Play();
                }
                else
                {
                    this.GetComponents<AudioSource>()[0].Stop();
                }
            }
            animator.SetFloat("Movement", movement);


            if (!isRobotLegs && Input.GetAxis("Vertical") < 0)
            {
                crouch = true;
            }

            // Try to jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
                animator.SetTrigger("Jump");
                this.GetComponents<AudioSource>()[1].Play();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                isRobotLegs = !isRobotLegs;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                isRobotArms = !isRobotArms;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                isRobotBrain = !isRobotBrain;
            }

            if (!controller.m_wasCrouching && Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetTrigger("Attack");

                if (isRobotArms)
                {
                    var bounds = boxCollider.bounds;
                    var minPos = new Vector2(bounds.min.x, bounds.min.y);
                    var maxPos = new Vector2(bounds.max.x, bounds.max.y);

                    var colliders = Physics2D.OverlapBoxAll(bounds.center, bounds.size, 0.0f);
                    foreach(var collider in colliders)
                    {
                        var health = collider.GetComponent<Health>();
                        if(health)
                        {
                            health.TakeDamage(robotDamage);
                        }
                    }
                }
                else if (lastShot + ReloadTime <= Time.time)
                {
                    GameObject newProjectile = Instantiate(Projectile, projectileSpawn.position, Quaternion.identity);
                    newProjectile.GetComponent<Rigidbody2D>().AddForce(ProjectileForce * new Vector2(transform.localScale.x * -1, 1));
                    lastShot = Time.time;
                    this.GetComponents<AudioSource>()[2].Play();
                }

                
            }            
        }

        animator.SetBool("IsRobotHand", isRobotArms);
    }

    private void FixedUpdate()
    {
        controller.Move(movement, crouch, jump);

        jump = false;
        crouch = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Environment")
        {
            Vector3 hitPos = Vector3.zero;

            if (collision.contacts.Length > 0)
            {
                hitPos.x = collision.contacts[0].point.x;
                hitPos.y = collision.contacts[0].point.y;

                var tilemap = collision.gameObject.GetComponent<Tilemap>();
                var tilePosition = tilemap.WorldToCell(hitPos);
                var tile = tilemap.GetTile(tilePosition);

                if (tile is BreakableTile)
                {
                    BreakableTile.Break(tilePosition, tilemap);
                }
            }

        }
    }
}
