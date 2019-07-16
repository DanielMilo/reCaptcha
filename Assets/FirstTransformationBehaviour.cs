using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTransformationBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFirstChoice(bool isRobotLeg)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBehaviour>().isRobotLegs = isRobotLeg;
    }
}
