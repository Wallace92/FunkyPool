using System;
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
}