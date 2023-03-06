using System.ComponentModel;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TurnModel))]
public class TurnPresenter : Presenter<TurnModel>
{
    [SerializeField]
    private TextMeshProUGUI m_turnText;

    private void Start() => UpdateTurnView();
    
    public void SetMaxTurnNumber(int maxTurnNumber) => Model.MaxTurnNumber = maxTurnNumber;

    public void IncreaseTurn(int amount) => Model.IncreaseScore(amount);
    public void RestartTurn() => Model.Restart();


    protected override void OnPropertyChange(object sender, PropertyChangedEventArgs e)
    {
        if (sender is not TurnModel)
            return;

        if (e.PropertyName == nameof(TurnModel.Turn))
            UpdateTurnView();
    }
    
    private void UpdateTurnView() => m_turnText.text = $"Turn: {Model.Turn}/{Model.MaxTurnNumber}";
}