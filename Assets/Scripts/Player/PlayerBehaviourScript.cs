using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    private Vector2 movement;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float standingSpeed;
    [SerializeField]
    private float crawlingSpeed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private bool isOnGround;

    public bool isSneaking;

    // Start is called before the first frame update
    void Start()
    {
        this.speed = this.standingSpeed;
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

    void Jump()
    {
        Stand();
        this.movement.y = jumpSpeed;
    }

    void Stand()
    {
        this.speed = this.standingSpeed;
    }

    void Crawl()
    {
        this.speed = this.crawlingSpeed;
    }

    void HandleInput()
    {
        movement = Vector2.zero;
        this.movement.x = Input.GetAxis("Horizontal") * speed;

        if (isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }
}
