using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public static bool isGameStarted;
    public static bool youLose;
    public static bool levelComplete;
    public static bool finishLineisPassed;

    public int score { get; private set; }
    public static int totalScore { get; set; }

    [SerializeField] Text scoreText;
    [SerializeField] Text levelCompleteScoreText;
    [SerializeField] GameObject startingText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject levelCompletePanel;

    void Start()
    {
        score = 0;

        score += totalScore;

        youLose = false;
        isGameStarted = false;
        finishLineisPassed = false;

        levelCompleteScoreText.text = totalScore.ToString();
        scoreText.text = score.ToString();
    }

    private void FixedUpdate()
    {
        if (levelComplete)
        {
            levelCompletePanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (youLose && !finishLineisPassed)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            isGameStarted = true;
            startingText.SetActive(false);
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        totalScore = score;

        scoreText.text = score.ToString();
        levelCompleteScoreText.text = totalScore.ToString();
    }

    public void ResetLevel()
    {
        Debug.Log("Reset level");
        Time.timeScale = 1;
        youLose = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Debug.Log("Next level");
        LevelGenerator.currentLevel++;
        Time.timeScale = 1;
        levelComplete = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
