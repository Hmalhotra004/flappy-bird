using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool isGameOver = false;
    public AudioSource pointSfx;
    [SerializeField] private ParticleSystem cloud = default;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        pointSfx.Play();
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
    }

    public void exit()
    {
        SceneManager.LoadScene("StartMenuScene");
    }

    private void Update()
    {
        if (!isGameOver) { 
            cloud.Play();
        }
    }
}
