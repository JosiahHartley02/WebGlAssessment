using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    //A reference to an object to look at
    [SerializeField]
    private GameObject _gameObject;

    // Update is called once per frame
    void Update()
    {
        //Sets the rotation so that this agents forward points to the _gameObject
        transform.LookAt(_gameObject.transform);
    }
}
