using UnityEngine;

public class FoodProjectile : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         
        if(   collision.gameObject.tag == "Character")
        {
            var character = collision.gameObject.GetComponent<Character>();
            if( character != null ) {character.EatFood(); }
            if (character != null)
            {
                Destroy(character.gameObject);
                Destroy(gameObject);
            }
        }
    }

    public void SetDish(SO_Dish dish)
    {
        spriteRenderer.sprite = dish.uiVisual;
    }
}
