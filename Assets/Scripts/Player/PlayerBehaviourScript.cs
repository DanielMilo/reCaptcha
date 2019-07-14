using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    [SerializeField]
    public Vector2 movement { get; set; }
    [SerializeField]
    public float speed { get; set; }
    [SerializeField]
    public float jumpSpeed { get; set; }
    [SerializeField]
    public bool isOnGround { get; set; }
    [SerializeField]
    public float noiseRange { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        var deltaPosition = this.movement * Time.fixedDeltaTime;
        this.transform.position += new Vector3(deltaPosition.x, deltaPosition.y, 0);
    }

    void HandleInput()
    {
        var movement = this.movement;
        movement.x = Input.GetAxis("horizontal") * speed;

        if (isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movement.y = jumpSpeed;
            }
        }

        this.movement = movement;
    }
}
