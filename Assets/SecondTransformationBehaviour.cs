using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTransformationBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFirstChoice(bool isRobotHand)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBehaviour>().isRobotArms = isRobotHand;
    }
}
