using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int m_maxTurnNumber;

    [SerializeField]
    private WhiteSphere m_whiteSphere;

    private void Awake() => m_whiteSphere.TurnPresenter.SetMaxTurnNumber(m_maxTurnNumber);

    public List<Sphere> Spheres = new List<Sphere>();

    public bool SpheresDontMove => Spheres.All(sphere => !sphere.IsMoving);
}
