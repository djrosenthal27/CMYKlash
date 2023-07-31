using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopAnimation : MonoBehaviour
{
    Transform parent;
    public void Delete()
    {
        parent.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Dead")
        {
            GameObject.FindWithTag("Board").transform.GetChild(4).gameObject.SetActive(true);
            GameObject.FindWithTag("Board").transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
            GameObject.FindWithTag("Board").transform.GetChild(4).GetChild(3).gameObject.SetActive(true);
        }
    }

    public void RemoveSprite()
    {
        parent = this.gameObject.transform.parent;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        parent.GetComponent<SpriteRenderer>().enabled = false;
        parent.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.transform.parent = null;
    }
}
