using UnityEngine;

public interface IMoveInput
{
    public float Horizontal();
    public float Vertical();
    public Vector3 InputUpdate();
}