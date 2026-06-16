using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public Canvas gameOverOverlay;
    public Canvas mainMenuOverlay;
    public bool isGameActive = true;

    private float spawnRate = 1.0f;
    private int score;

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
        isGameActive = false;
        gameOverOverlay.gameObject.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        isGameActive = true;

        UpdateScore(0);
        mainMenuOverlay.gameObject.SetActive(false);

        StartCoroutine(SpawnTarget());
        spawnRate /= difficulty;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
