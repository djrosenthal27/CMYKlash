using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 2;
    public SpriteRenderer sprite;
    public int dir = 0;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Color[] colors = { Color.cyan, Color.yellow, Color.magenta, Color.cyan };
        sprite.color = colors[Random.Range(0, 3)];
        if (sprite.color == Color.cyan)
        {
            this.tag = "Cyan";
        }
        if (sprite.color == Color.yellow)
        {
            this.tag = "Yellow";
        }
        if (sprite.color == Color.magenta)
        {
            this.tag = "Magenta";
        }
        switch (transform.position.x)
        {
            case 10:
                dir = 0;
                break;
            case -10:
                dir = 1;
                break;
        }
        switch (transform.position.y)
        {
            case 6:
                dir = 2;
                break;
            case -6:
                dir = 3;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == 0)
            transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
        if (dir == 1)
            transform.position = transform.position + (Vector3.right * moveSpeed * Time.deltaTime);
        if (dir == 2)
            transform.position = transform.position + (Vector3.down * moveSpeed * Time.deltaTime);
        if (dir == 3)
            transform.position = transform.position + (Vector3.up * moveSpeed * Time.deltaTime);

        if (transform.position.x < -18 || transform.position.y < -18)
        {
            Destroy(gameObject);
        }
    }
}
