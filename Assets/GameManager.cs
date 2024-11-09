using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private float gameTime = 60f;
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

    
    private void Update()
    {
        gameTime -= Time.deltaTime;
        timeText.text = gameTime.ToString("F2");
        if (gameTime <= 0)
        {
            gameTime = 0;
            GameOver();
        }
    }

    public void HandleFoodEaten()
    {
        gameTime += 5f;
    }

    public void HandleFoodRotten()
    {
        gameTime -= 2f;
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
