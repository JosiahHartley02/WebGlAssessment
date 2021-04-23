using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Reference to the gameObject that we want to spawn
    [SerializeField]
    private GameObject spawnThis;
    [SerializeField]
    //The time inbetween spawns
    private float spawnBuffer;
    //The toggle switch for spawning enemies
    private bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        //Creates a loop
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        while (!GameOver)
        {
            //Spawn in an instance of the pipe prefab at the given position with a default
            GameObject enemy = Instantiate(spawnThis, transform.position, new Quaternion());
            //Wait for the given time interval before resuming the function
            yield return new WaitForSeconds(spawnBuffer);
        }
    }
}
