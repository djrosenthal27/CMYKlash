using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempRegenInvincibility : MonoBehaviour
{
    GameObject player;

    public void Restart(GameObject player)
    {
        Debug.Log("Restart");
       // player = GameObject.FindWithTag("Player");

        player.transform.GetChild(1).gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        player.transform.GetChild(2).gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        player.transform.GetChild(3).gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        player.transform.GetChild(7).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(7).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(8).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(9).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(9).gameObject.transform.GetChild(0).gameObject.SetActive(false);

        player.transform.GetChild(4).gameObject.GetComponent<CircleCollider2D>().enabled = false;
        player.transform.GetChild(5).gameObject.GetComponent<CircleCollider2D>().enabled = false;
        player.transform.GetChild(6).gameObject.GetComponent<CircleCollider2D>().enabled = false;

        player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);

        player.transform.GetChild(7).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        player.transform.GetChild(8).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        player.transform.GetChild(9).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);

        player.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        player.transform.GetChild(5).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        player.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);

        //player.GetComponent<PlayerMovement>().gameObject.SetActive(true);
        // GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void Reactivate()
    {
        Debug.Log("Reactivate");
        player = GameObject.FindWithTag("Player");

        if (player.GetComponent<PlayerMovement>().GetState() == "Triangle")
        {
            player.transform.GetChild(1).gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            player.transform.GetChild(2).gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            player.transform.GetChild(3).gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }

        player.transform.GetChild(7).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        player.transform.GetChild(7).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        player.transform.GetChild(8).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        player.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        player.transform.GetChild(9).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        player.transform.GetChild(9).gameObject.transform.GetChild(0).gameObject.SetActive(true);

        player.transform.GetChild(4).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        player.transform.GetChild(5).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        player.transform.GetChild(6).gameObject.GetComponent<CircleCollider2D>().enabled = true;

        player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);

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
