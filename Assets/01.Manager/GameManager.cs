using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStopPlay
{
    GameStop,
    GamePlay
}

public enum GameState
{
    None,
    Clear,
    GameOver
}

public enum GameStage
{
    None,
    Stage1,
    Stage2
}

public class GameManager : MonoSigleton<GameManager>
{
    [SerializeField] private GameStopPlay currentGameStopPlay;

    public GameStopPlay CurrentGameStopPlay => currentGameStopPlay;

    public GameState gameState;
    public GameStage gameStage;

    public void ClearGame()
    {
        Time.timeScale = 0;
        currentGameStopPlay = GameStopPlay.GameStop;
        gameState = GameState.Clear;
        ScoreSystem.Instance.AddTotalScore();
        GameStateUIManager.Instance.ActiveGameStateUI(gameState);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        currentGameStopPlay = GameStopPlay.GameStop;
        gameState = GameState.GameOver;
        GameStateUIManager.Instance.ActiveGameStateUI(gameState);
    }
}
