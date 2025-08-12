using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hightText;
    public TextMeshProUGUI overText;

    public GameObject gameOverPanel;
    public GameObject gameStartPanel;
    public void SetScoreText(float score)
    {
        scoreText.text = "" + score;
    }
    public void SetHightText(float hight)
    {
        hightText.text = "" + hight;
    }
    public void SetHightScoreTXT(float hight)
    {
        overText.text = "Max Score: " + hight;
    }
    public void SetGameStartPanel()
    {
        gameStartPanel.SetActive(true);
    }
    public void SetGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void SetPlay()
    {
        gameOverPanel.SetActive(false);
        gameStartPanel.SetActive(false);

        GameManager.Instance.SetPlayLogic();
    }    
}
