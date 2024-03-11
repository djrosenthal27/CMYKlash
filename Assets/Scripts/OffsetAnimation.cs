using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Offsets the default animations of the corner/vertex circles so that they are not all in-synch with each other
public class OffsetAnimation : MonoBehaviour
{
    public float offset;

    // Plays the default vertex animation with the given offset
    void Start()
    {
        GetComponent<Animator>().Play("VertexAnimation", 0, offset);
    }

}
