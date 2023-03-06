using System.ComponentModel;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TurnModel))]
public class TurnPresenter : Presenter<TurnModel>
{
    [SerializeField]
    private TextMeshProUGUI m_turnText;
    
    public void IncreaseTurn(int amount) => Model.IncreaseScore(amount);
    public void RestartTurn() => Model.Restart();
    
    private new void Awake()
    {
        base.Awake();
        UpdateScoreView();
    }
    
    protected override void OnPropertyChange(object sender, PropertyChangedEventArgs e)
    {
        if (sender is not TurnModel)
            return;

        if (e.PropertyName == nameof(TurnModel.Turn))
            UpdateScoreView();
    }
    
    private void UpdateScoreView() => m_turnText.text = $"Turn: {Model.Turn}";
}