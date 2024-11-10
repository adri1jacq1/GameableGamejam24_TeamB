using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private UI_DishInventory dishInventory;


    public float speed;

    public float rotationSpeed;


    public float projectilleSpeed;
    public float projectilleSpawnDistance;
    public Rigidbody2D rigidbody2D;
    public FoodProjectile foodPrefab;
    public SpriteRenderer canon;
    public ParticleSystem particleSystem;

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = Input.GetAxis("Vertical") * speed * transform.up;
        if(Input.GetAxis("Vertical")<0)
        {
            rigidbody2D.angularVelocity = Input.GetAxis("Horizontal") * rotationSpeed;
        }
        else rigidbody2D.angularVelocity = -Input.GetAxis("Horizontal") * rotationSpeed;
        UpdateCanonRotation();

        if (Input.GetButtonUp("Fire1"))
        {
            Fire();
        }
    }

    private void UpdateCanonRotation()
    {
        var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.z = 0;
        direction = direction.normalized;
        canon.transform.eulerAngles = new Vector3(0.0f,0.0f,-Vector3.SignedAngle(direction, Vector3.left, Vector3.forward));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var food = collision.gameObject.GetComponent<Food>();
        if (food != null && !dishInventory.IsFull())
        {
            canon.color = Color.green;
            dishInventory.AddDish(food.dish);
            Destroy(food.gameObject);
        }
        if (food != null && dishInventory.IsFull())
        { 
            Destroy(food.gameObject);
        }
    }

    private void Fire()
    {
        if (dishInventory.HasFood())
        {
            var food = Instantiate<FoodProjectile>(foodPrefab);
            food.SetDish(dishInventory.RemoveDish());
            var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            direction = direction.normalized;
            food.rigidbody2D.position = transform.position + direction * projectilleSpawnDistance;
            food.rigidbody2D.velocity = direction.normalized * projectilleSpeed;
            canon.color = Color.white;
            particleSystem.Play();
        }
    }
}
