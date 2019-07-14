using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    [SerializeField]
    public Vector2 movement;
    [SerializeField]
    private float speed { get; set; }
    [SerializeField]
    public float standingSpeed { get; set; }
    [SerializeField]
    public float crawlingSpeed { get; set; }
    [SerializeField]
    public float jumpSpeed { get; set; }
    [SerializeField]
    public bool isOnGround { get; set; }
    [SerializeField]
    public float noiseRange { get; set; }

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
        this.movement.x = Input.GetAxis("horizontal") * speed;

        if (isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }
}
