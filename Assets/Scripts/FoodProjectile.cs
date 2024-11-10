using UnityEngine;

public class FoodProjectile : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if(collision.collider.tag == "Character")
        {
            var character = collision.gameObject.GetComponent<Character>();
            if (character != null)
            {
                Destroy(character.gameObject);
                Destroy(gameObject);
            }
        }
    }

}
