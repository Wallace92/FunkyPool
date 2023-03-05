using UnityEngine;

public class RedSphere : Sphere,  IScore
{
    [SerializeField]
    private int m_scoreIncrement;
    public int ScoreIncrement => m_scoreIncrement;
}