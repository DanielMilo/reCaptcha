using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdTransformationBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFirstChoice(bool isRobothead)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBehaviour>().isRobotBrain = isRobothead;
    }
}
