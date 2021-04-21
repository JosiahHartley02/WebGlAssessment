using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnThis;
    [SerializeField]
    private float spawnBuffer;
    private bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
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
