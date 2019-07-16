using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [SerializeField] int damage = 1;

    // Start is called before the first frame update
    private void Start()
    {
        var colliders = Physics2D.OverlapCircleAll(this.transform.position, this.transform.localScale.x);
        foreach(var collider in colliders)
        {
            var health = collider.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(damage);
            }
        }

        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
