using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] asteroide;
    Vector3 spawnPos;

    int randomSpawn;

    public float maxTime;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomSpawn = Random.Range(0, 5);
        time -= 1 * Time.deltaTime;
        if (time <= 0)
        {
            if (randomSpawn == 0 | randomSpawn < 3)
            {
                spawnPos = new Vector3((int)Random.Range(-6, 6), 8, 0);

                GameObject x = Instantiate(asteroide[randomSpawn], spawnPos, transform.rotation);
                time = maxTime;

                Destroy(x, 10);
            }
        }
    }
}
