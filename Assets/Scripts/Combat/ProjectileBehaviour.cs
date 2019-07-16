using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ProjectileBehaviour::OnCollisionEnter2D BOOM!");
        // TODO deal damage

        if(explosion)
            Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
