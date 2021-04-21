using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTaggedInZone : MonoBehaviour
{
    [SerializeField]
    private string TagName;
    [SerializeField]
    private GameObject GameManager;
    private BoxCollider _boxCollider;
    private void OnTriggerEnter(Collider other)
    {
        DieInTaggedZone dieScript = other.GetComponent<DieInTaggedZone>();
        if (dieScript)
            dieScript.Destroy();
    }
}
