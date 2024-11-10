using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private UI_IngredientsInventory ingredientInventory;


    public float speed;

    public float rotationSpeed;


    public float projectilleSpeed;
    public float projectilleSpawnDistance;
    public Rigidbody2D rigidbody2D;
    public FoodProjectile foodPrefab;
    public SpriteRenderer canon;
    public ParticleSystem particleSystem;

    bool hasFood = false;

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = Input.GetAxis("Vertical") * speed * transform.up;
        rigidbody2D.angularVelocity = -Input.GetAxis("Horizontal") * rotationSpeed;
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
        if (food != null && !hasFood)
        {
            hasFood = true;
            canon.color = Color.green;
            ingredientInventory.TryAddIngredient(food.ingredient);
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
            canon.color = Color.white;
            particleSystem.Play();
        }
    }
}
