using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{
    [SerializeField] private Text[] rankingText;
    [SerializeField] private Ranking ranking;
    [SerializeField] private Animator startAnim;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            startAnim.SetBool("isMove", true);

            if (startAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && startAnim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMove"))
            {
                StageSystem.Instance.NextScene();
            }
        }
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
