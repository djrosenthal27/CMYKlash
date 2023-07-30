using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject Homing;
    public float spawnRate = 2;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        int x, y;
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                if (Random.Range(0, 2) == 0)
                {
                    y = Random.Range(-4, 4);
                    x = 10;
                }
                else
                {
                    y = Random.Range(-4, 4);
                    x = -10;
                }
            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    x = Random.Range(-9, 9);
                    y = 6;
                }
                else
                {
                    x = Random.Range(-4, 4);
                    y = -6;
                }
            }
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(Homing, new Vector3(x, y, transform.position.z), transform.rotation);
            }
            else
                Instantiate(Enemy, new Vector3(x, y, transform.position.z), transform.rotation);
            timer = 0;
        }
    }
}
