using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTaggedInZone : MonoBehaviour
{
    //The Tag of the gameObjects that we want to kill
    [SerializeField]
    private string TagName;
    //The box Collider that will act as a killzone
    [SerializeField]
    private BoxCollider _boxCollider;
    //When something enters the killzone
    private void OnTriggerEnter(Collider other)
    {
        //try to initialize a DieInTaggedZone instance to test if the other has a dieInTaggedZone script
        DieInTaggedZone dieScript = other.GetComponent<DieInTaggedZone>();
        if (dieScript)
            //if they do, then destroy the object
            dieScript.Destroy();
    }
}
