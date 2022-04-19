using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float spawnRate = 2.0f;

    private float nextSpawn = 1f;

    public float radius = 4.0f;

    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > nextSpawn)
        {

            Instantiate(prefabs[Random.Range(0,prefabs.Length)], Random.insideUnitSphere * radius + transform.position, Quaternion.identity);
            //Will set the nextspawn of the prefab to currentTime + spawnRate, so when it should spawn next
            nextSpawn = Time.time + spawnRate;
        }
    }
}
