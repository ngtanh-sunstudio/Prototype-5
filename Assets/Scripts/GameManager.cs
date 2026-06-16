using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public Canvas gameOverOverlay;
    public Canvas mainMenuOverlay;
    public Canvas pauseOverlay;
    public AudioSource audioSource;
    public bool isGameActive = false;
    public bool isPaused = false;

    private float baseSpawnRate = 1.0f;
    private float spawnRate;
    private int score;
    private int lives;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            if (!isGameActive)
            {
                yield break;
            }

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToAdd)
    {
        if (lives <= 0 && livesToAdd < 0)
        {
            return;
        }

        lives = Mathf.Max(0, lives + livesToAdd);
        livesText.text = "Lives: " + lives;
        if (lives == 0 && isGameActive)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverOverlay.gameObject.SetActive(true);
    }

    void OnEnable()
    {
        DifficultyButton.DifficultySelected += StartGame;
        VolumeSlider.VolumeChanged += ChangeVolume;
        PauseEvent.PausePressed += TogglePause;
    }

    
    void OnDisable()
    {
        DifficultyButton.DifficultySelected -= StartGame;
        VolumeSlider.VolumeChanged -= ChangeVolume;
        PauseEvent.PausePressed -= TogglePause;
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        lives = 5;
        isGameActive = true;
        isPaused = false;
        Time.timeScale = 1f;

        spawnRate = baseSpawnRate / difficulty;

        UpdateScore(0);
        UpdateLives(0);
        mainMenuOverlay.gameObject.SetActive(false);
        pauseOverlay.gameObject.SetActive(false);
        gameOverOverlay.gameObject.SetActive(false);

        StartCoroutine(SpawnTarget());
    }

    public void TogglePause()
    {
        if (!isGameActive)
        {
            return;
        }

        if (isPaused)
        {
            pauseOverlay.gameObject.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            pauseOverlay.gameObject.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
