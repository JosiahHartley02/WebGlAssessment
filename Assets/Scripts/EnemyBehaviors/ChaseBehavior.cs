using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehavior : MonoBehaviour
{
    //A reference to the game object that this agent will be pathing towards
    [Tooltip("The object the enemy will be seeking towards.")]
    [SerializeField]
    private GameObject _target;
    //A reference to the pathing component of this game object
    private NavMeshAgent _agent;
    //A reference to the rigidbody component of this game object
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //Initialize the rigid body to be this gameObjects rigidBody component
        _rigidbody = GetComponent<Rigidbody>();
        //Initialize the pathing to be this gameObjects pathing component
        _agent = GetComponent<NavMeshAgent>();
        if (!_target)
            //if the target was not specified, default to targeting the player
            _target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //If a target hasn't been set return
        if (!_target)
            return;
        //Set the position to path to, the navigation component will do the rest
        _agent.SetDestination(_target.transform.position);
    }
}
