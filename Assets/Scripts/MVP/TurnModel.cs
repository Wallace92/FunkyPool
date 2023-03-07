
public class TurnModel : Model
{
    private int m_turn = 1;
    public int Turn
    {
        get => m_turn; 
        set => SetValue(value, ref m_turn);
    }

    public int MaxTurnNumber { get; set; }

    public void IncreaseScore(int amount) => Turn += amount;
    public void Restart() => Turn = 0;
}