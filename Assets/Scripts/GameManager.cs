using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ScorePresenter m_scorePresenter;
    
    [SerializeField]
    private int m_maxTurnNumber;

    private List<Sphere> m_spheres = new List<Sphere>();
    private WhiteSphere m_whiteSphere;
    
    private void Awake()
    {
        m_spheres = FindObjectsOfType<Sphere>().ToList();
        m_whiteSphere = FindObjectOfType<WhiteSphere>();
    }

    private void Start()
    {
        if (m_whiteSphere != null)
            m_whiteSphere.Constructor(this, m_maxTurnNumber);
    }


    private void Update()
    {
        if (m_whiteSphere.TurnPresenter.GetTurnNumber() == m_maxTurnNumber)
            Debug.Log("Congratulation your score is: " + m_scorePresenter.GetScore());
    }

    public bool SpheresDontMove => m_spheres.All(sphere => !sphere.IsMoving);
}
