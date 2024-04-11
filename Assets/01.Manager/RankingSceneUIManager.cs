using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingSceneUIManager : MonoBehaviour
{
    [SerializeField] private Text[] rankingText;
    [SerializeField] private Ranking ranking;
    [SerializeField] private InputField inputfield;

    private void Start()
    {
        RankingText();
    }

    public void AddRank()
    {
        ranking.AddRank(new Rank(inputfield.text, ScoreSystem.totalScore));
        RankingText();
    }

    public void RankingText()
    {
        for (int i = 0; i < ranking.ranks.Count; i++)
        {
            rankingText[i].text = $"{i + 1}. {ranking.ranks[i].name} : {ranking.ranks[i].score}";
        }

        for (int i = ranking.ranks.Count; i < rankingText.Length; i++)
        {
            rankingText[i].text = $"{i + 1}. 랭킹이 없습니다.";
        }
    }
}
