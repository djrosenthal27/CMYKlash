using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapOut : MonoBehaviour
{
    /*public GameObject YeMaLine;
    public GameObject CyYeLine;
    public GameObject MaCyLine;*/
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

        GameObject player = GameObject.FindWithTag("Player");

        player.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        player.transform.GetChild(5).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        player.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
    }

    public void Detatch()
    {
        this.transform.parent = null;

  //      player.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
 //       player.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
  //      player.transform.GetChild(6).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

    void Start()
    {
        movementSpeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetInitMoveSpeed();
        rotationSpeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetInitRotationSpeed();
    }

    public void Reactivate()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.GetChild(4).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        player.transform.GetChild(5).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        player.transform.GetChild(6).gameObject.GetComponent<CircleCollider2D>().enabled = true;

        player.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        player.transform.GetChild(5).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        player.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);

        /*Destroy(player.transform.GetChild(7).gameObject, 0.0f);
        Destroy(player.transform.GetChild(8).gameObject, 0.0f);

        Instantiate(YeMaLine, new Vector3(0, 0, 0), Quaternion.identity, player.transform);
        Instantiate(CyYeLine, new Vector3(0, 0, 0), Quaternion.identity, player.transform);
        Instantiate(MaCyLine, new Vector3(0, 0, 0), Quaternion.identity, player.transform);*/

        this.gameObject.SetActive(false);

        //   player.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        //    player.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        //   player.transform.GetChild(6).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }


}
