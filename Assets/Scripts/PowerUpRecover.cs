using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRecover : PowerUpCode
{
    public GameObject Player;
    public GameObject YeMaPlayer;
    public GameObject CyYePlayer;
    public GameObject MaCyPlayer;
    public override void Activate()
    {
        Debug.Log("Regen");
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Triangle")
        {

        }
        else if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Line")
        {
            Vector3 pos = GameObject.FindWithTag("Player").transform.position;
            Quaternion rotation = GameObject.FindWithTag("Player").transform.rotation;
            Destroy(GameObject.FindWithTag("Player"), 0.0f);
            Instantiate(Player, pos, rotation);
        }
        else if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Dot")
        {
            if (GameObject.FindWithTag("Player").transform.GetChild(4).gameObject.activeSelf)
            {
                Vector3 pos = GameObject.FindWithTag("Player").transform.position;
                Quaternion rotation = GameObject.FindWithTag("Player").transform.rotation;
                Destroy(GameObject.FindWithTag("Player"), 0.0f);
                Instantiate(YeMaPlayer, pos, rotation);
            }
            else if (GameObject.FindWithTag("Player").transform.GetChild(5).gameObject.activeSelf)
            {
                Vector3 pos = GameObject.FindWithTag("Player").transform.position;
                Quaternion rotation = GameObject.FindWithTag("Player").transform.rotation;
                Destroy(GameObject.FindWithTag("Player"), 0.0f);
                Instantiate(MaCyPlayer, pos, rotation);
            }

            else if (GameObject.FindWithTag("Player").transform.GetChild(6).gameObject.activeSelf)
            {
                Vector3 pos = GameObject.FindWithTag("Player").transform.position;
                Quaternion rotation = GameObject.FindWithTag("Player").transform.rotation;
                Destroy(GameObject.FindWithTag("Player"), 0.0f);
                Instantiate(CyYePlayer, pos, rotation);
            }

            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().SetState("Line");
           // Debug.Log(GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState());
        }

    }

    public override void Update()
    {
        if (shouldUpdate)
        {

            if (timer < duration)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                shouldUpdate = false;
                Destroy(gameObject, 0.0f);
            }

        }
    }
}
