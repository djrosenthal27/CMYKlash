using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetAnimation : MonoBehaviour
{
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("VertexAnimation", 0, offset);
    }

}
