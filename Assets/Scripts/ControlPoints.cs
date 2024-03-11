using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the number of points the player has and handles enemy death
public class ControlPoints : MonoBehaviour
{
    // Increases score (and if applicable, multiplier) upon enemy death, and activates death animation
    public void DefeatEnemy(GameObject enemy)
    {
        transform.GetChild(0).gameObject.GetComponent<UpdateScore>().ChangeScore();
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Triangle")
        {
            transform.GetChild(1).gameObject.GetComponent<UpdateMultiplier>().IncreaseKill();
        }
        enemy.GetComponent<Animator>().SetTrigger("Active");
    }
}
