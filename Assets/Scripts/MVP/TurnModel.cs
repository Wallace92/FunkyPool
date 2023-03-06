
public class TurnModel : Model
{
    private int m_turn;
    public int Turn
    {
        get => m_turn; 
        set => SetValue(value, ref m_turn);
    }

    public void IncreaseScore(int amount) => Turn += amount;
    public void Restart() => Turn = 0;
}