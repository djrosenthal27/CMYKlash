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





        //player.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        //player.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        //player.transform.GetChild(6).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

    public void Restart()
    {

        player.transform.GetChild(7).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        player.transform.GetChild(8).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        player.transform.GetChild(9).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);

        player.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        player.transform.GetChild(5).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        player.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);

        player.GetComponent<PlayerMovement>().movementSpeed = movementSpeed;
        player.GetComponent<PlayerMovement>().rotationSpeed = rotationSpeed;
        //player.GetComponent<PlayerMovement>().gameObject.SetActive(true);
        // GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void Reactivate()
    {

        player.transform.GetChild(7).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        player.transform.GetChild(7).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        player.transform.GetChild(8).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        player.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        player.transform.GetChild(9).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        player.transform.GetChild(9).gameObject.transform.GetChild(0).gameObject.SetActive(true);

        player.transform.GetChild(4).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        player.transform.GetChild(5).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        player.transform.GetChild(6).gameObject.GetComponent<CircleCollider2D>().enabled = true;

        player.transform.GetChild(7).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        player.transform.GetChild(8).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        player.transform.GetChild(9).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);

        player.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        player.transform.GetChild(5).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        player.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);

       // player.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
       // player.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
       // player.transform.GetChild(6).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }
}
