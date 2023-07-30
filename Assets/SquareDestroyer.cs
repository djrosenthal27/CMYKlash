using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareDestroyer : MonoBehaviour
{
    public void DestroySquare()
    {
        Destroy(transform.parent, 0.0f);
    }
}
