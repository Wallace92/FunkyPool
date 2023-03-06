using System;
using System.ComponentModel;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(ScoreModel))]
public class ScorePresenter : Presenter<ScoreModel>
{
    [SerializeField]
    private TextMeshProUGUI m_scoreText;

    private void Start() => UpdateScoreView();

    public void IncreaseScore(int amount) => Model.IncreaseScore(amount);
    public void RestartScore() => Model.Restart();

    protected override void OnPropertyChange(object sender, PropertyChangedEventArgs e)
    {
        if (sender is not ScoreModel) 
            return;
        
        if (e.PropertyName == nameof(ScoreModel.Score))
            UpdateScoreView();
    }
    private void UpdateScoreView() => m_scoreText.text = $"Score: {Model.Score}";
}

