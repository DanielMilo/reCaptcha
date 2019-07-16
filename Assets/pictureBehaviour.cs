using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pictureBehaviour : MonoBehaviour
{
    private SpriteRenderer renderer;
    private GameObject player;

    [SerializeField] Sprite humanPic;
    [SerializeField] Sprite robotPic;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<CharacterBehaviour>().isRobotBrain)
        {
            renderer.sprite = robotPic;
        }
        else
        {
            renderer.sprite = humanPic;
        }
    }
}
