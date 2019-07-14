using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private float movement;
    private CharacterController controller;
    private bool jump = false;

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
    }

    private void FixedUpdate()
    {
        controller.Move(movement, false, jump);

        jump = false;
    }
}
