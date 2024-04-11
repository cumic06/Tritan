using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateUIManager : MonoSigleton<GameStateUIManager>
{
    [SerializeField] private Image gameStateImage;
    [SerializeField] private Image gameClearImage;

    [SerializeField] private Text gameStateText;
    [SerializeField] private Text playTimeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private Text gameClearPlayTimeText;
    [SerializeField] private Text gameClearScoreText;

    [SerializeField] private Button clearBtn;
    [SerializeField] private Button gameOverBtn;


    public void ActiveGameStateUI(GameState gameState)
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            if (gameState == GameState.Clear)
            {
                gameStateText.text = "Clear";
                clearBtn.gameObject.SetActive(true);
            }
            if (gameState == GameState.GameOver)
            {
                gameStateText.text = "GameOver";
                gameOverBtn.gameObject.SetActive(true);
            }
            gameStateImage.gameObject.SetActive(true);
            playTimeText.text = $"PlayTime {TimeManager.Instance.Min:00}:{TimeManager.Instance.currentTime:F2}";
            scoreText.text = $"Score : {ScoreSystem.Instance.GetScore():N0}";
        }
        else
        {
            gameClearImage.gameObject.SetActive(true);
            gameClearPlayTimeText.text = $"PlayTime {TimeManager.Instance.Min:00}:{TimeManager.Instance.currentTime:F2}";
            gameClearScoreText.text = $"Score : {ScoreSystem.Instance.GetScore():N0}";
            totalScoreText.text = $"Total Score : {ScoreSystem.totalScore:N0}";
        }
    }
}
