using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [SerializeField] float timeToLive;
    private float creationTime;

    // Start is called before the first frame update
    void Awake()
    {
        creationTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(creationTime + timeToLive <= Time.time)
        {
            Destroy(gameObject);
        }
    }
}
