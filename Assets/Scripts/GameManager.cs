using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    public static GameManager Instance;
    public int score = 0;
    public TMP_Text scoreText;
    public AudioClip GameOver;
    private AudioSource AudioSource3;

    public int initialHealth = 3;
    public GameObject gameOverUI;

    private void Awake()
    {
        Instance = this;
    }

    void Start()


    {
        AudioSource3 = GetComponent<AudioSource>(); 
        if (AudioSource3 == null)
        {
            Debug.LogError("AudioSource component missing from this game object. Please add an AudioSource component.");
        }

        playerHealth.health = initialHealth;
        UpdateScoreText();
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        

        if (AudioSource3 != null && GameOver != null)
        {
            AudioSource3.PlayOneShot(GameOver); 
        }
        else
        {
            Debug.LogError("Missing AudioSource or Shoot Sound. Please assign both in the Inspector.");
        }

        

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
        score += amount; 
        UpdateScoreText(); 
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); 
        }
    }
}
