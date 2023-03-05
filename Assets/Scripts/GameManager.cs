using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Sphere> Spheres = new List<Sphere>();

    public bool SpheresDontMove => Spheres.All(sphere => !sphere.IsMoving);
}
