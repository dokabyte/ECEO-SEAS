using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public TMP_Text scoreText;

    public int initialHealth = 3;
    public GameObject gameOverUI;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PlayerHealth.health = initialHealth;
        UpdateScoreText();
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void AddScore(int amount)
    {
        score += amount; // Adiciona pontos
        UpdateScoreText(); // Atualiza o texto da pontuação na UI
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Atualiza o texto da pontuação na UI
        }
    }
}
