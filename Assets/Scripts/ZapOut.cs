using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapOut : MonoBehaviour
{ 
    public void Zap()
    {
        while (transform.localScale.x > 0)
        {
            gameObject.transform.localScale = new Vector3(-.1f, .1f, 0);
        }
        gameObject.SetActive(false);
    }
}
