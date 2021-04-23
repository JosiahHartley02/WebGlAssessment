using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieInTaggedZone : MonoBehaviour
{
    //The tag of the kill zone that this game object will destroy in
    [SerializeField]
    private string Tag;
    //A reference to the gamemanager to keep track of the number of despawned enemies
    [SerializeField]
    private GameObject GameManager;
    //A reference to the gamemanagers script to keep track of the number of despawned enemies
    private GameUIManager _gameUIManager;
    //a bool that helps prevent an agent from being worth more than 1 point
    private bool _counted = false;
    //Called once at the start of initialization
    public void Start()
    {
        //Initialize the gameManager to be the gameObject with the tag
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        //sets the gameuimanager to be the gameObjects script
        _gameUIManager = GameManager.GetComponent<GameUIManager>();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    //When this collides
    private void OnTriggerEnter(Collider other)
    {
        //check to see if the game object this collided with has the tag of the kill zone
        if (other.CompareTag(Tag))
        {
            //if it does, destroy this agent
            Destroy();
            //if this agent hasn't been counted
            if (!_counted)
            {
                //count this agent
                _gameUIManager.IncrementScore();
                //mark this agent as counted
                _counted = !_counted;
            }
        }
    }
}
