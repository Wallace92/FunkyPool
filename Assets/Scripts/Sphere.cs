using UnityEngine;

public abstract class Sphere : MonoBehaviour
{
    protected Rigidbody Rigidbody;
    void Start() => Rigidbody = GetComponent<Rigidbody>();
}