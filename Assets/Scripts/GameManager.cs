using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int highScore = 0;
    public bool isDie = false;

    public GameUI gameUI;
    public Transform playPos;
    public GameObject player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        gameUI.SetGameStartPanel();
        SetGameStar();
    }
    public void SetGameStar()
    {
        isDie = true;
        score = 0;
        gameUI.SetScoreText(score);
    }    
    public void SetGameOver()
    {
        isDie = true;
        score = 0;
        gameUI.SetScoreText(score);
        gameUI.SetHightScoreTXT(highScore);
        gameUI.SetGameOverPanel();
    }
    public void SetPlayLogic()
    {
        isDie = false;
        score = 0;
        gameUI.SetScoreText(score);
        gameUI.SetHightText(highScore);

        Instantiate(player, playPos.position, Quaternion.identity);
    }    
    public void IncreaseScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        gameUI.SetScoreText(score);
        gameUI.SetHightText(highScore);
    }

    public void ResetScore()
    {
        score = 0;
        gameUI.SetScoreText(score);
        gameUI.SetHightText(highScore);
    }
}
