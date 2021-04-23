using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //A reference to the gameObject to follow
    [SerializeField]
    GameObject _player;
    //The distance that this agent will maintain from the player
    [Tooltip("The placement of the character in relation to the position of the player")]
    [SerializeField]
    Vector3 _distance;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the gameObject to be the player
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Set this agent to be x units away, at the height of y units, and z units away
        transform.position = new Vector3(_player.transform.position.x + _distance.x, _distance.y, _player.transform.position.z + _distance.z);
    }
}
