public class ScoreSystem : MonoSigleton<ScoreSystem>
{
    private int score;
    public static int totalScore;
    private ScoreUIManager scoreUI;

    protected override void Awake()
    {
        base.Awake();
        scoreUI = GetComponent<ScoreUIManager>();
    }

    private void Start()
    {
        AddScore(0);
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreUI.SetScoreUI(score);
    }

    public void AddTotalScore()
    {
        totalScore += score;
    }

    #region Bouns
    public int HpPerScore()
    {
        int hpPer = (Player.Instance.CurrentHp / Player.Instance.GetMaxHp());
        return hpPer;
    }

    public int TimeBounsScore()
    {
        int timeScore = (int)TimeManager.Instance.GetTime();
        return timeScore;
    }

    public void BonusScore()
    {
        score += TimeBounsScore() + HpPerScore();
    }
    #endregion
}