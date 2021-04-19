using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehavior : MonoBehaviour
{
    public float Speed;

    [SerializeField]
    private GameObject _player;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = (_player.transform.position - transform.position).normalized * Speed * Time.deltaTime;

        //Call to make the rigidbody smoothly move to the desired position
        _rigidbody.MovePosition(transform.position + directionToPlayer);
    }
}
