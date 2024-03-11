using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An abstract class controlling an enemy
public abstract class AbstractEnemyScript : MonoBehaviour
{
    public float moveSpeed;

    public Sprite cyanSprite;
    public RuntimeAnimatorController cyanAnim;
    public Sprite yellowSprite;
    public RuntimeAnimatorController yellowAnim;
    public Sprite magentaSprite;
    public RuntimeAnimatorController magentaAnim;

    private SpriteRenderer sprite;

    // Assigns a new enemy a random color: either Cyan, Yellow, or Magenta
    public void Initialize()
    {
        sprite = GetComponent<SpriteRenderer>();
        Color[] colors = { Color.cyan, Color.yellow, Color.magenta };
        sprite.color = colors[Random.Range(0, 3)];
        if (sprite.color == Color.cyan)
        {
            this.tag = "Cyan";
            sprite.sprite = cyanSprite;
            GetComponent<Animator>().runtimeAnimatorController = cyanAnim;
        }
        if (sprite.color == Color.yellow)
        {
            this.tag = "Yellow";
            sprite.sprite = yellowSprite;
            GetComponent<Animator>().runtimeAnimatorController = yellowAnim;
        }
        if (sprite.color == Color.magenta)
        {
            this.tag = "Magenta";
            sprite.sprite = magentaSprite;
            GetComponent<Animator>().runtimeAnimatorController = magentaAnim;
        }
    }
}
