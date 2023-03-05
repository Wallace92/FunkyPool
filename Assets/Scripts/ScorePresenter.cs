using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
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

    public void IncreaseScore(int amount) => m_scoreModel.IncreaseScore(amount);
    public void RestartScore() => m_scoreModel.Restart();
    
    private void OnPropertyChange(object sender, PropertyChangedEventArgs e)
    {
        switch (sender)
        {
            case ScoreModel scoreModel:
                if (e.PropertyName == nameof(scoreModel.Score))
                    UpdateScoreView();
                break;
        }
    }

    private void UpdateScoreView() => m_scoreText.text = m_scoreModel.Score.ToString();
}