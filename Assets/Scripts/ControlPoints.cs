using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoints : MonoBehaviour
{
    public void DefeatEnemy(GameObject gameObject)
    {
        transform.GetChild(0).gameObject.GetComponent<UpdateScore>().ChangeScore();
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Triangle")
        {
            transform.GetChild(1).gameObject.GetComponent<UpdateMultiplier>().IncreaseKill();
        }
        Destroy(gameObject, 0.0f);
    }
}
