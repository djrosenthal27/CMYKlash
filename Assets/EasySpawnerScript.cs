using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySpawnerScript : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnRate;
    public float minSpawnRate;
    public float timer = 0;
    public Transform box;
    float overallTimer;
    // Start is called before the first frame update
    void Start()
    {
        overallTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (overallTimer > 20 && spawnRate - 0.5f >= 0.5f)
        {
            overallTimer = 0;
            spawnRate = spawnRate - 0.5f;
        }
        else if (overallTimer > 20 && spawnRate - 0.1f >= 0.3f)
        {
            overallTimer = 0;
            spawnRate = spawnRate - 0.1f;
        }
        else 
        { 
            overallTimer = overallTimer + Time.deltaTime;
        }

        int x, y;
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else if (!box.GetComponent<SlowedDown>().slowedDown)
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
            Instantiate(Enemy, new Vector3(x, y, transform.position.z), transform.rotation, box);
   //         if (box.GetComponent<SlowedDown>().slowedDown)
    //        {
   //             box.GetChild(box.childCount - 1).GetComponent<AbstractEnemyScript>().moveSpeed = box.GetChild(box.childCount - 1).GetComponent<AbstractEnemyScript>().moveSpeed / 2.0f;
         //   }
            timer = 0;
        }
    }
}