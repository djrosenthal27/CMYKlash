using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

public class EnemyScript : AbstractEnemyScript
{
   // public float moveSpeed = 2;
    public SpriteRenderer sprite;
    public int dir = 0;
    public Sprite cyanCircle;
    public RuntimeAnimatorController cyanPop;
    public Sprite yellowCircle;
    public RuntimeAnimatorController yellowPop;
    public Sprite magentaCircle;
    public RuntimeAnimatorController magentaPop;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Color[] colors = {Color.cyan, Color.yellow, Color.magenta};
        sprite.color = colors[Random.Range(0, 3)];
        if (sprite.color == Color.cyan)
        {
            this.tag = "Cyan";
            sprite.sprite = cyanCircle;
            GetComponent<Animator>().runtimeAnimatorController = cyanPop;
        }
        if (sprite.color == Color.yellow)
        {
            this.tag = "Yellow";
            sprite.sprite = yellowCircle;
            GetComponent<Animator>().runtimeAnimatorController = yellowPop;
        }
        if (sprite.color == Color.magenta)
        {
            this.tag = "Magenta";
            sprite.sprite = magentaCircle;
            GetComponent<Animator>().runtimeAnimatorController = magentaPop;
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

        if (transform.position.x < -14 || transform.position.y < -10 || transform.position.x > 14 || transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject, 0.0f);
    }
}
