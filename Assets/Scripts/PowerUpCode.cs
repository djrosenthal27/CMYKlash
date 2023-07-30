using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpCode : MonoBehaviour
{
    public bool shouldUpdate;
    public float timer;
    public float duration;

    void Start()
    {
        shouldUpdate = false;
        timer = 0;
    }

    public void PowerUp()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        shouldUpdate = true;
        Activate();
    }

    public void Display()
    {

    }

    abstract public void Activate();

    abstract public void Update();
}
