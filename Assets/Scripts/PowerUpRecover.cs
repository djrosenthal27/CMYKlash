using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRecover : PowerUpCode
{
    public GameObject Player;
    public GameObject YeMaPlayer;
    public GameObject CyYePlayer;
    public GameObject MaCyPlayer;
    public float powerSpinDuration;
    bool shouldPowerSpin;

    public override void Activate()
    {
        shouldPowerSpin = false;
        Debug.Log("Regen");
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Triangle")
        {
            GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindWithTag("Player").transform.GetChild(11).gameObject.SetActive(true);
            GameObject.FindWithTag("Player").transform.GetChild(11).gameObject.GetComponent<Animator>().SetTrigger("Active");
            shouldPowerSpin = true;
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
            if (shouldPowerSpin)
            {
                if (timer < powerSpinDuration)
                {
                    timer = timer + Time.deltaTime;
                }
                else
                {
                    GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindWithTag("Player").transform.GetChild(11).gameObject.SetActive(false);
                    shouldUpdate = false;
                    Destroy(gameObject, 0.0f);
                }
            } 
            else
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
}
