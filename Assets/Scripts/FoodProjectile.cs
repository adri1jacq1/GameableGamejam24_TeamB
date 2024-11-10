using UnityEngine;

public class FoodProjectile : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

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

}
