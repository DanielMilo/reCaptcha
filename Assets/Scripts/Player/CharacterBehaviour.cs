using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private float movement;
    private CharacterController controller;
    private bool jump = false;
    private bool crouch = false;

    [SerializeField] float WalkingSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * WalkingSpeed;

        // Try to jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            crouch = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(movement, crouch, jump);

        jump = false;
        crouch = false;
    }
}
