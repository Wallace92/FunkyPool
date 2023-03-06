using UnityEngine;

public class Pillar : MonoBehaviour
{
    public ScorePresenter ScorePresenter;

    private void Start() => ScorePresenter.RestartScore();

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.TryGetComponent<IScore>(out var sphere)) 
            return;
        
        ScorePresenter.IncreaseScore(sphere.ScoreIncrement);
        other.gameObject.SetActive(false);
    }
}

