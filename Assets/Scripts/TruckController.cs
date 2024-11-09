using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public float projectilleSpeed;
    public Rigidbody2D rigidbody2D;
    public FoodProjectile foodPrefab;

    bool hasFood = false;

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical") * speed;
        var horizontal = Input.GetAxis("Horizontal") * speed;
        rigidbody2D.velocity = new Vector3(horizontal, vertical, 0);

        if(Input.GetButtonUp("Fire1"))
        {
            Fire();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        var food = collision.collider.gameObject.GetComponent<Food>();
        if (food != null && !hasFood)
        {
            hasFood = true;
            Destroy(food.gameObject);
        }
    }

    private void Fire()
    {
        if (hasFood)
        {
            var food = Instantiate<FoodProjectile>(foodPrefab);
            var direction = Input.mousePosition - transform.position;
            food.rigidbody2D.position = transform.position;
            food.rigidbody2D.velocity = direction.normalized * projectilleSpeed;
            hasFood = false;
        }
    }
}
