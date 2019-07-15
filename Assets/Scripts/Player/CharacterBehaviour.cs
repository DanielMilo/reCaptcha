using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] Transform respawnCheckpoint;

    [SerializeField] bool isRobotLegs;
    [SerializeField] bool isRobotArms;
    [SerializeField] bool isRobotBrain;

    [SerializeField] GameObject Projectile;
    [SerializeField] Transform projectileSpawn;
    [SerializeField] Vector2 ProjectileForce;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        controller.OnCrouchEvent.AddListener(OnCrouch);
    }

    void OnCrouch(bool newCrouchState)
    {
        animator.SetBool("Crouching", newCrouchState);
    }

    void OnLand()
    {
        animator.SetTrigger("HitGround");
    }

    void OnHit(int damage)
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
        movement = Input.GetAxis("Horizontal") * WalkingSpeed;
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
        }

        if(!controller.m_wasCrouching && Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("Attack");

            if (isRobotArms)
            {
                // melee
            }
            else
            {
                GameObject newProjectile = Instantiate(Projectile, projectileSpawn.position, Quaternion.identity);
                newProjectile.GetComponent<Rigidbody2D>().AddForce(ProjectileForce * new Vector2(transform.localScale.x,1));
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
}
