using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class HomingScript : AbstractEnemyScript
{
    public Transform target;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
   // public float moveSpeed = 5f;
    public float rotateSpeed = 200f;
    public Sprite cyanSquare;
    public AnimatorController cyanFizz;
    public Sprite yellowSquare;
    public AnimatorController yellowFizz;
    public Sprite magentaSquare;
    public AnimatorController magentaFizz;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        sprite = GetComponent<SpriteRenderer>();
        Color[] colors = { Color.cyan, Color.yellow, Color.magenta };
        sprite.color = colors[Random.Range(0, 3)];
        if (sprite.color == Color.cyan)
        {
            this.tag = "Cyan";
            sprite.sprite = cyanSquare;
            GetComponent<Animator>().runtimeAnimatorController = cyanFizz;
        }
        if (sprite.color == Color.yellow)
        {
            this.tag = "Yellow";
            sprite.sprite = yellowSquare;
            GetComponent<Animator>().runtimeAnimatorController = yellowFizz;
        }
        if (sprite.color == Color.magenta)
        {
            this.tag = "Magenta";
            sprite.sprite = magentaSquare;
            GetComponent<Animator>().runtimeAnimatorController = magentaFizz;
        }
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (timer < 10)
        {
            timer = timer + Time.deltaTime;
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * moveSpeed;
        } 
        else
        {
            target = null;
            if (transform.position.x < -14 || transform.position.y < -10 || transform.position.x > 14 || transform.position.y > 10)
            {
                Destroy(gameObject);
            }
        }
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject, 0.0f);
    }

    public void DestroyChild()
    {
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
