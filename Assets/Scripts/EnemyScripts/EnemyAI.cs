using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] CharacterController _character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if grounded
        // calculate direction = destination(player or target)-source (self (transform)
        //calculate velocity direction * speed


        //subtract gravity 
        //move to velocity 

        // look at player script
    }
}
