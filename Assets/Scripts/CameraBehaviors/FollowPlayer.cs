using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject _player;
    [Tooltip("The placement of the character in relation to the position of the player")]
    [SerializeField]
    Vector3 _distance;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x + _distance.x, _distance.y, _player.transform.position.z + _distance.z);
    }
}
