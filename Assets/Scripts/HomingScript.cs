using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingScript : AbstractEnemyScript
{
    public Transform target;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
   // public float moveSpeed = 5f;
    public float rotateSpeed = 200f;
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
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * moveSpeed;
    }
}
