
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverText;

    [SerializeField]private TMP_Text scoreText;

    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    public bool isGameOver;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }

    public void ButtonRestarGame()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void CargarSiguienteNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        int siguienteIndex = ++escenaActual;
        SceneManager.LoadScene(siguienteIndex);
    }
}
