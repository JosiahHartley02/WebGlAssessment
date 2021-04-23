using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Roll backwards on the forward rotation vector
        transform.Rotate(transform.forward, -2);
    }
}
