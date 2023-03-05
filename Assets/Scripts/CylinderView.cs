using UnityEngine;

public class CylinderView : MonoBehaviour
{
    public ScorePresenter ScorePresenter;

    private void Start() => ScorePresenter.RestartScore();

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.TryGetComponent<IScore>(out var sphere)) 
            return;
        
        ScorePresenter.IncreaseScore(sphere.ScoreIncrement);
        Destroy(other.gameObject);
    }
}