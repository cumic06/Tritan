using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedSystem : MonoSigleton<GameSpeedSystem>
{
    public void GameTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}
