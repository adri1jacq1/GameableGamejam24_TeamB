using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        var horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Debug.Log(vertical);
        Debug.Log(horizontal);
        transform.Translate( new Vector3(horizontal, vertical, 0));
    }
}
