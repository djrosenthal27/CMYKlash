using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingScript : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D rigidBody;
    public SpriteRenderer sprite;
    public float angleChangingSpeed = 10;
    public float movementSpeed = 2;
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
        rigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.transform.position - rigidBody.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigidBody.angularVelocity = -angleChangingSpeed * rotateAmount;
        rigidBody.velocity = transform.up * movementSpeed;
        if (transform.position.x < -18 || transform.position.y < -12 || transform.position.x > 18 || transform.position.y > 12)
        {
            Destroy(gameObject);
        }
    }
}
