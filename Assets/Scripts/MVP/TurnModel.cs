
public class TurnModel : Model
{
    private int m_turn = 1;
    public int Turn
    {
        get => m_turn; 
        set => SetValue(value, ref m_turn);
    }
    
    private int m_maxTurnNumber;

    public int MaxTurnNumber
    {
        get => m_maxTurnNumber;
        set => m_maxTurnNumber = value;
    }

    public void IncreaseScore(int amount) => Turn += amount;
    public void Restart() => Turn = 0;
}