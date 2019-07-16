using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerBehaviour : MonoBehaviour
{
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            Debug.Log("DeathTriggerBehaviour::OnTriggerEnter2D Player Entered");
            player.GetComponent<CharacterBehaviour>().OnHit(int.MaxValue);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
