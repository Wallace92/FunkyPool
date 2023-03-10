using System.ComponentModel;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TurnModel))]
public class TurnPresenter : Presenter<TurnModel>
{
    [SerializeField]
    private TextMeshProUGUI m_turnText;

    public void Constructor(int maxTurnNumber)
    {
        Model.MaxTurnNumber = maxTurnNumber;
        UpdateTurnView();
    }

    public void IncreaseTurn(int amount) => Model.IncreaseScore(amount);
    public int GetTurnNumber() => Model.Turn;

    protected override void OnPropertyChange(object sender, PropertyChangedEventArgs e)
    {
        if (sender is not TurnModel)
            return;

        if (e.PropertyName == nameof(TurnModel.Turn))
            UpdateTurnView();
    }
    
    private void UpdateTurnView() => 
        m_turnText.text = $"Turn: {Model.Turn}/{Model.MaxTurnNumber}";
}