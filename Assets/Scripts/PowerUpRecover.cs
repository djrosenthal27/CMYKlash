using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the Recover (Tetrahedron) Powerup
public class PowerUpRecover : PowerUpCode
{
    public GameObject Player;
    public GameObject YeMaPlayer;
    public GameObject CyYePlayer;
    public GameObject MaCyPlayer;
    public float powerSpinDuration;
    bool shouldPowerSpin;

    // Recovers a vertex for the player. Effects depend on player's current state
    public override void Activate()
    {
        shouldPowerSpin = false;

        // If player is a triangle, indicate that Power-Spin mode should be active and play Power-Spin animation.
        // Power-Spin is temporary invincibility that defeats any enemies that come in contact
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Triangle")
        {
            GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindWithTag("Player").transform.GetChild(11).gameObject.SetActive(true);
            GameObject.FindWithTag("Player").transform.GetChild(11).gameObject.GetComponent<Animator>().SetTrigger("Active");
            shouldPowerSpin = true;
        }
        // If player is a line, replace player object with a full-health triangle player.
        // Give temporary invincibility where the player cannot attack enemies
        else if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Line")
        {
            Vector3 pos = GameObject.FindWithTag("Player").transform.position;
            Quaternion rotation = GameObject.FindWithTag("Player").transform.rotation;
            Destroy(GameObject.FindWithTag("Player"), 0.0f);
            this.gameObject.GetComponent<TempRegenInvincibility>().Restart(Instantiate(Player, pos, rotation));
        }
        // If player is a dot, replace player with a line player depending on which dot is active. 
        // Give temporary invincibility where the player cannot attack enemies
        else if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Dot")
        {
            if (GameObject.FindWithTag("Player").transform.GetChild(4).gameObject.activeSelf)
            {
                Vector3 pos = GameObject.FindWithTag("Player").transform.position;
                Quaternion rotation = GameObject.FindWithTag("Player").transform.rotation;
                Destroy(GameObject.FindWithTag("Player"), 0.0f);
                this.gameObject.GetComponent<TempRegenInvincibility>().Restart(Instantiate(YeMaPlayer, pos, rotation));
            }
            else if (GameObject.FindWithTag("Player").transform.GetChild(5).gameObject.activeSelf)
            {
                Vector3 pos = GameObject.FindWithTag("Player").transform.position;
                Quaternion rotation = GameObject.FindWithTag("Player").transform.rotation;
                Destroy(GameObject.FindWithTag("Player"), 0.0f);
                this.gameObject.GetComponent<TempRegenInvincibility>().Restart(Instantiate(MaCyPlayer, pos, rotation));
            }

            else if (GameObject.FindWithTag("Player").transform.GetChild(6).gameObject.activeSelf)
            {
                Vector3 pos = GameObject.FindWithTag("Player").transform.position;
                Quaternion rotation = GameObject.FindWithTag("Player").transform.rotation;
                Destroy(GameObject.FindWithTag("Player"), 0.0f);
                this.gameObject.GetComponent<TempRegenInvincibility>().Restart(Instantiate(CyYePlayer, pos, rotation));
            }

            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().SetState("Line");
        }

    }

    // Displays appropriate timer text for the duration of the powerup
    public override void Update()
    {
        if (shouldUpdate)
        {
            if (shouldPowerSpin)
            {
                // If Power-Spin is active, display appropriate text
                if (timer < powerSpinDuration)
                {
                    GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("Invincibility: " + (int)(powerSpinDuration - timer));
                    timer = timer + Time.deltaTime;
                }
                // If timer exceeds duration, end the Power-Spin mode
                else
                {
                    GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindWithTag("Player").transform.GetChild(11).gameObject.SetActive(false);
                    GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("");
                    shouldUpdate = false;
                    Destroy(gameObject, 0.0f);
                }
            } 
            else
            {
                // If temporary invicibility is active, display appropriate text
                if (timer < duration)
                {
                    GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("Recover");
                    timer = timer + Time.deltaTime;
                }
                // If timer exceeds duration, clear the powerup text
                else
                {
                    this.gameObject.GetComponent<TempRegenInvincibility>().Reactivate();
                    GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("");
                    shouldUpdate = false;
                    Destroy(gameObject, 0.0f);
                }
            }

        }
    }
}
