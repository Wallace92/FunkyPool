using Observer;

public class ScoreModel : Model
{
    private int m_score;
    public int Score
    {
        get => m_score; 
        set => SetValue(value, ref m_score);
    }

    public void IncreaseScore(int amount) => Score += amount;
    public void Restart() => Score = 0;
}