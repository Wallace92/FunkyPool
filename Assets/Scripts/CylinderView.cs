using UnityEngine;

public class CylinderView : MonoBehaviour
{
    public ScorePresenter ScorePresenter;

    private void Start()
    {
        ScorePresenter.RestartScore();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ScorePresenter.IncreaseScore(1);
        else if (Input.GetMouseButtonDown(1))
            ScorePresenter.RestartScore();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<IScore>(out var sphere))
        {
            Debug.Log("Collision with a Sphere detected, " + sphere.ScoreIncrement);
            // Do something here, like destroying the GameObject or applying damage
        }
    }
}