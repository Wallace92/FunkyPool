using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool LevelCompleted;

    public bool SpheresDontMove => m_spheres.All(sphere => !sphere.IsMoving);

    [SerializeField]
    private ScorePresenter m_scorePresenter;

    [SerializeField]
    private int m_maxTurnNumber;

    private WhiteSphere m_whiteSphere;
    private List<Pillar> m_pillars = new List<Pillar>();
    private List<Sphere> m_spheres = new List<Sphere>();

    private void Awake()
    {
        m_spheres = FindObjectsOfType<Sphere>().ToList();
        m_pillars = FindObjectsOfType<Pillar>().ToList();
        m_whiteSphere = FindObjectOfType<WhiteSphere>();
    }

    private void Start()
    {
        if (m_whiteSphere != null)
            m_whiteSphere.Constructor(this, m_maxTurnNumber);

        foreach (var pillar in m_pillars)
        {
            pillar.Constructor(m_scorePresenter);
        }
        
        m_scorePresenter.RestartScore();
    }

    private void Update()
    {
        if (LevelCompleted || m_whiteSphere.TurnPresenter.GetTurnNumber() != m_maxTurnNumber)
            return;
        
        Debug.Log("Congratulation your score is: " + m_scorePresenter.GetScore());
        LevelCompleted = true;
    }
}
