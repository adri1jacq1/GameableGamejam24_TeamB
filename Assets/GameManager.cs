using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject charachterBar360;
    public FoodSpawnHandler foodSpawnHandler;
    public static GameManager Instance { get; private set; }
    public float healthStartTime = 20f;
    public float lvlConstTime = 30;
    public float lvlTime;
    private float healthTime;
    float gameTime;
    public TMPro.TextMeshProUGUI timeText;
    public int eatingFoodHealthAmount = 5;
    public int rottenFoodHealthAmount = 2;
    int lvl;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (foodSpawnHandler ==null) foodSpawnHandler = FindFirstObjectByType<FoodSpawnHandler>();
        healthTime = healthStartTime;
        lvl = 0;
    } 

    private void Update()
    {
        healthTime -= Time.deltaTime;
        gameTime += Time.deltaTime;
        lvlTime += Time.deltaTime; 
        timeText.text =  "Level : "+  lvl.ToString("F2") + " health  " + healthTime.ToString("F2");
        float rotationAmount = (healthStartTime - healthTime) * 360 / healthStartTime;
        if (rotationAmount > 360)
        {
            rotationAmount = 360;
        }
        charachterBar360.transform.rotation = Quaternion.Euler(0, 0, rotationAmount);
        if (healthTime < 0)
        {
            healthTime = 0;
            GameOver();
        }
        if (lvlTime > lvlConstTime)
        {
            HandleNextLevelVariables( );
        }
    }
    public void HandleNextLevelVariables( )
    {
        lvl += 1;
        lvlTime = 0;
        if (lvl>3)  return;
        foodSpawnHandler.spawningTime -= 1;
        

    }

    public void HandleFoodEaten()
    { 
        healthTime +=  eatingFoodHealthAmount;
    }

    public void HandleFoodRotten()
    {
        //healthTime -=  rottenFoodHealthAmount;
    }

    private void GameOver()
    {
        Debug.Log("Game Over! Time's up.");
        // Additional game-over actions
    }

    public float GethealthTime()
    {
        return healthTime;
    }
}
