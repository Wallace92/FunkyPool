using System.ComponentModel;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(ScoreModel))]
public class ScorePresenter : MonoBehaviour
{
    private ScoreModel m_scoreModel;
    
    [SerializeField]
    private TextMeshProUGUI m_scoreText;

    private void Awake()
    {
        m_scoreModel = GetComponent<ScoreModel>();
        m_scoreModel.PropertyChange += OnPropertyChange;
        
        UpdateScoreView();
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
    
    private void OnDestroy() => m_scoreModel.PropertyChange -= OnPropertyChange;
}