using UnityEngine;

public abstract class Sphere : MonoBehaviour
{
    protected Rigidbody Rigidbody;
    public bool IsMoving => Rigidbody.velocity.sqrMagnitude > 0;
    
    protected void Awake() => Rigidbody = GetComponent<Rigidbody>();
}