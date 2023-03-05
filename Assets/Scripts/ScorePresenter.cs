using System.ComponentModel;
using TMPro;
using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField]
    private ScoreModel m_scoreModel;
    
    [SerializeField]
    private TextMeshProUGUI m_scoreText;

    private void Awake()
    {
        if (m_scoreModel != null)
            m_scoreModel.PropertyChange += OnPropertyChange;
        
        UpdateScoreView();
    }

    private void OnDestroy()
    {
        if (m_scoreModel != null)
            m_scoreModel.PropertyChange -= OnPropertyChange;
    }

    public void IncreaseScore(int amount) => m_scoreModel.IncreaseScore(amount);
    public void RestartScore() => m_scoreModel.Restart();
    
    private void OnPropertyChange(object sender, PropertyChangedEventArgs e)
    {
        if (sender is not ScoreModel) 
            return;
        
        if (e.PropertyName == nameof(ScoreModel.Score))
            UpdateScoreView();
    }

    private void UpdateScoreView() => m_scoreText.text = m_scoreModel.Score.ToString();
}