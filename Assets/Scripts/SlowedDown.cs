using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// States whether an EnemyBox is affected by the SlowDown powerup or not
public class SlowedDown : MonoBehaviour
{
    public bool isSlowedDown;

    // Initializes EnemyBox to not be slowed down. Changes on activation fo SlowDown powerup
    void Start()
    {
        isSlowedDown = false;  
    }

}
