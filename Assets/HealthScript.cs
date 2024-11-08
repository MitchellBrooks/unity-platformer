using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private int maxHealth = 3;
    private int health = 3;

    public SpriteRenderer heartSprite1;
    public SpriteRenderer heartSprite2;
    public SpriteRenderer heartSprite3;
    public Sprite heart;
    public Sprite emptyHeart;

    void Start() {
    }

    public void decrementHealth(int count) {
        health += count;
        this.loadCorrectSprite();
    }

    public void incrementHealth(int count) {
        health += count;
        if(health > maxHealth) {
            health = maxHealth;
        }
        this.loadCorrectSprite();
    }

    private void loadCorrectSprite() {
        switch(health) {
            case 1:
                heartSprite1.sprite = this.heart;
                heartSprite2.sprite = this.emptyHeart;
                heartSprite3.sprite = this.emptyHeart;
                break;
            case 2:
                heartSprite1.sprite = this.heart;
                heartSprite2.sprite = this.heart;
                heartSprite3.sprite = this.emptyHeart;
                break;
            case 3:
                heartSprite1.sprite = this.heart;
                heartSprite2.sprite = this.heart;
                heartSprite3.sprite = this.heart;
                break;
            case 0:
                heartSprite1.sprite = this.emptyHeart;
                heartSprite2.sprite = this.emptyHeart;
                heartSprite3.sprite = this.emptyHeart;
                break;
        }
    }
}
