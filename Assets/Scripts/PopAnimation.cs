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
