using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpSpawnerScript : MonoBehaviour
{
    public float spawnRate;
    public GameObject SpeedUpPlayer;
    public GameObject SlowEnemies;
    public GameObject RecoverVertex;
    public GameObject DestroyEnemies;
    float timer = 0;
    GameObject currentPowerup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Board").transform.GetChild(2).GetComponent<TextMeshProUGUI>().text != "")
        {
            timer = 0;
        }
        else if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else if (currentPowerup == null)
        {
            int random = Random.Range(0, 10);
            int randomX = Random.Range(-7, 8);
            int randomY = Random.Range(-3, 4);
            if (random == 9)
            {
                currentPowerup = Instantiate(RecoverVertex, new Vector3(randomX, randomY, 0), Quaternion.identity);
            }
            else if (random == 8 || random == 7)
            {
                currentPowerup = Instantiate(DestroyEnemies, new Vector3(randomX, randomY, 0), Quaternion.identity);
            }
            else if (random == 6 || random == 5 || random == 4)
            {
                currentPowerup = Instantiate(SpeedUpPlayer, new Vector3(randomX, randomY, 0), Quaternion.identity);
            }
            else
            {
                currentPowerup = Instantiate(SlowEnemies, new Vector3(randomX, randomY, 0), Quaternion.identity);
            }
            timer = 0;
        }
        else
        {
            Destroy(currentPowerup, 0.0f);
            timer = 0;
        }
    }
}
