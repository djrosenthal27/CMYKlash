using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapOut : MonoBehaviour
{

    float movementSpeed;
    float rotationSpeed;
    public void Zap()
    {
        if (transform.localScale.x > 0)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + .1f, gameObject.transform.localScale.y - .1f, 0);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Delete()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().movementSpeed = movementSpeed;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rotationSpeed = rotationSpeed;
        this.gameObject.SetActive(false);
    }

    public void Detatch()
    {
        this.transform.parent = null;
    }

    void Start()
    {
        movementSpeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().movementSpeed;
        rotationSpeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rotationSpeed;
    }

}
