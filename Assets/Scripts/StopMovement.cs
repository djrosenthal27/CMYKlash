using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    public GameObject player;
    float movementSpeed;
    float rotationSpeed;

    void Start()
    {
        movementSpeed = player.GetComponent<PlayerMovement>().movementSpeed;
        rotationSpeed = player.GetComponent<PlayerMovement>().rotationSpeed;
    }

    public void Stop()
    {
        player.GetComponent<PlayerMovement>().movementSpeed = 0;
        player.GetComponent<PlayerMovement>().rotationSpeed = 0;
       // player.GetComponent<PlayerMovement>().gameObject.SetActive(false);
        // GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void Restart()
    {
        player.GetComponent<PlayerMovement>().movementSpeed = movementSpeed;
        player.GetComponent<PlayerMovement>().rotationSpeed = rotationSpeed;
        //player.GetComponent<PlayerMovement>().gameObject.SetActive(true);
        // GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
