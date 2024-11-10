using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject charachterBar360;
    public static GameManager Instance { get; private set; }
    public float TotalGameTime = 60f;
    private float gameTime;
    public TMPro.TextMeshProUGUI timeText;
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
        gameTime = 0;
    } 

    private void Update()
    {
        gameTime += Time.deltaTime;
        timeText.text = gameTime.ToString("F2");
        charachterBar360.transform.rotation = Quaternion.Euler(0, 0, gameTime * 360 / TotalGameTime);
        if (gameTime > TotalGameTime)
        {
            gameTime = 0;
            GameOver();
        }
    }

    public void HandleFoodEaten()
    {
        gameTime -= 5f;
    }

    public void HandleFoodRotten()
    {
        gameTime += 2f;
    }

    private void GameOver()
    {
        Debug.Log("Game Over! Time's up.");
        // Additional game-over actions
    }

    public float GetGameTime()
    {
        return gameTime;
    }
}
