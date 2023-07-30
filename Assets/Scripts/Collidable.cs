using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public bool collided;
    
    // Start is called before the first frame update
    void Start()
    {
        collided = false;
    }
}
