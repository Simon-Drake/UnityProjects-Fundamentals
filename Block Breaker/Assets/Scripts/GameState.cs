using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    // Configuration
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 1;
    [SerializeField] bool isAutoPlayEnabled;


    // State variables
    [SerializeField] int currentScore = 0;


    // Cached references
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        int gameStateCount = FindObjectsOfType<GameState>().Length;
        if (gameStateCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Set speed
        Time.timeScale = gameSpeed;
    }

    // Update score
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    // Destroy game state, called when game starts/restarts.
    public void DestroyGameState()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled(){
        return isAutoPlayEnabled;
    }
}
