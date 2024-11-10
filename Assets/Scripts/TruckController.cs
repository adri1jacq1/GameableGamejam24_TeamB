using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;

    public float rotationSpeed;


    public float projectilleSpeed;
    public float projectilleSpawnDistance;
    public Rigidbody2D rigidbody2D;
    public FoodProjectile foodPrefab;

    bool hasFood = false;

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = Input.GetAxis("Vertical") * speed * transform.up;
        rigidbody2D.angularVelocity = -Input.GetAxis("Horizontal") * rotationSpeed;

        if (Input.GetButtonUp("Fire1"))
        {
            Fire();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var food = collision.gameObject.GetComponent<Food>();
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
            var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            direction = direction.normalized;
            food.rigidbody2D.position = transform.position + direction * projectilleSpawnDistance;
            food.rigidbody2D.velocity = direction.normalized * projectilleSpeed;
            hasFood = false;
        }
    }
}
