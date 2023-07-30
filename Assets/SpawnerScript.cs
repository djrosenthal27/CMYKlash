using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject Enemy;
    public float spawnRate = 2;
    public float timer = 0;
    public Transform box;
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
            int height = Random.Range(-4, 4);
            Instantiate(Enemy, new Vector3(transform.position.x, height, transform.position.z), transform.rotation, box);
            if (box.GetComponent<SlowedDown>().slowedDown)
            {
                box.GetChild(box.childCount - 1).GetComponent<EnemyScript>().moveSpeed = box.GetChild(box.childCount - 1).GetComponent<EnemyScript>().moveSpeed / 2.0f;
            }
            timer = 0;
        }
    }
}
