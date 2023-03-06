using UnityEngine;

public class Pillar : MonoBehaviour
{
    private ScorePresenter m_scorePresenter;

    public void Constructor(ScorePresenter scorePresenter) => m_scorePresenter = scorePresenter;

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.TryGetComponent<IScore>(out var sphere)) 
            return;
        
        m_scorePresenter.IncreaseScore(sphere.ScoreIncrement);
        other.gameObject.SetActive(false);
    }
}

