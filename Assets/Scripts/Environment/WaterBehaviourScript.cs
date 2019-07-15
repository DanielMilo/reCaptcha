using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviourScript : MonoBehaviour
{
    CharacterBehaviour character;

    [SerializeField]
    public int damage = 1;

    [SerializeField]
    public float delay = 2.0f;

    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(character && character.isRobotBrain)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                character.OnHit(damage);
                timer -= delay;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        character = collision.gameObject.GetComponent<CharacterBehaviour>();
        character.OnHit(damage);
        timer = 0.0f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterBehaviour>() != null)
            character = null;
    }
}
