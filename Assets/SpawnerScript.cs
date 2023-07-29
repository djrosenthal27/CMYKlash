using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject Enemy;
    public float spawnRate = 2;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            int height = Random.Range(-5, 5);
            Instantiate(Enemy, new Vector3(transform.position.x, height, transform.position.z), transform.rotation);
            timer = 0;
        }
    }
}
