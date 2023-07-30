using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DjEnemyScript : MonoBehaviour
{
    public float moveSpeed = 2;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Color[] colors = {Color.cyan, Color.yellow, Color.magenta, Color.cyan};
        sprite.color = colors[Random.Range(0,3)];
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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);

        if(transform.position.x < -18)
        {
            Destroy(gameObject);
        }
    }
}
