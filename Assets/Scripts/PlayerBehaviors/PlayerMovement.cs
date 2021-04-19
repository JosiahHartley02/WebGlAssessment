using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Player's Speed")]
    [SerializeField]
    private float _moveSpeed = 0;
    [Tooltip("The distance the Player will travel per Second")]
    [SerializeField]
    private float _jumpHeight;

    private bool _jumping;

    [SerializeField]
    private Camera _camera;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //Store reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
    }

    bool AbleToJump()
    {
        if (_jumping)
            return false;
        return true; ;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 jumpForce = new Vector3(0, 0, 0);
        //Checks to see if the player is able to jump to narrow down the amount of functions ran per update

        if (Input.GetButtonDown("Jump") && AbleToJump())
        {
            jumpForce = new Vector3(0, _jumpHeight, 0);
        }
        //Create a ray that starts at a screen point
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        //Checks to see if the ray hits any object in the world
        if (Physics.Raycast(ray, out hit))
        {
            //Find the direction the player should look towards
            Vector3 lookDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            //Create a rotation from the player's forward to the look direction
            Quaternion rotation = Quaternion.LookRotation(lookDir);
            //Set the rotation to be the new rotation found
            _rigidbody.MoveRotation(rotation);
        }

        //The direction the player is looking in is set to the input values for the movement
        Vector3 moveDir = new Vector3(transform.forward.x, 0, transform.forward.z);
        //The move direction is scaled by the movement speed to get velocity
        Vector3 velocity = moveDir * _moveSpeed * Time.deltaTime;
        //Call to make the rigidbody smoothly move to the desired position
        _rigidbody.MovePosition(transform.position + velocity + jumpForce);
    }
}
