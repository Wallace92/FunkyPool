using UnityEngine;

public class BlueSphere : Sphere, IScore
{
    [SerializeField]
    private int m_scoreIncrement;
    public int ScoreIncrement => m_scoreIncrement;
}