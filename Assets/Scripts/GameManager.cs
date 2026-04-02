// notice ... List class requires System.Collections.Generic namespace
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    [Header("UI Elements")]
    // NOTE: TextMeshProUGUI requires "using TMPro"
    public TextMeshProUGUI scoreText;
    // NOTE: TextMeshProUGUI requires "using TMPro"
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    private int score;
    private bool isGameActive = true;
    private float spawnRate = 1.0f;

    void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        StartGame();
    }

    void StartGame()
    {
        StartCoroutine(SpawnTargets());
        UpdateScore(0);
        gameOverScreen.SetActive(false);
        isGameActive = true;
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

