using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoundaries : MonoBehaviour
{
    GameObject top;
    GameObject bottom;
    GameObject left;
    GameObject right;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        top = this.transform.GetChild(0).gameObject;
        bottom = this.transform.GetChild(1).gameObject;
        left = this.transform.GetChild(2).gameObject;
        right = this.transform.GetChild(3).gameObject;

        Vector3 bottomLeft = mainCam.ViewportToWorldPoint(Vector3.zero);
        Vector3 topRight = mainCam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        float height = topRight.y - bottomLeft.y;

        left.transform.localScale = new Vector3(0.5f, height - .5f, 1f);
        right.transform.localScale = new Vector3(0.5f, height - .5f, 1f);

        left.transform.localPosition = new Vector3(bottomLeft.x + .5f, 0f, 0f);
        right.transform.localPosition = new Vector3(topRight.x - .5f, 0f, 0f);

        float width = topRight.x - bottomLeft.x;

        top.transform.localScale = new Vector3(width - .5f, 0.5f, 1f);
        bottom.transform.localScale = new Vector3(width - .5f, 0.5f, 1f);

        top.transform.localPosition = new Vector3(0f, topRight.y - .5f, 0f);
        bottom.transform.localPosition = new Vector3(0f, bottomLeft.y + .5f, 0f);

        top.AddComponent<BoxCollider2D>();
        bottom.AddComponent<BoxCollider2D>();
        left.AddComponent<BoxCollider2D>();
        right.AddComponent<BoxCollider2D>();

    }

}