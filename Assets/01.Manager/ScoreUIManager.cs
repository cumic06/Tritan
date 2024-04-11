using UnityEngine;
using UnityEngine.UI;

public class ScoreUIManager : MonoSigleton<ScoreUIManager>
{
    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text scorePopTxt;

    public void SetScoreUI(int score)
    {
        scoreTxt.text = $"Score : {score:N0}";
    }

    public void ActivePopScoreUI(Vector3 pos, int score)
    {
        Text spawnScorePop = Instantiate(scorePopTxt, transform);
        spawnScorePop.text = $"{score}";
        spawnScorePop.transform.position = Camera.main.WorldToScreenPoint(pos);
    }
}
