
using UnityEngine;

public class WhiteSphere : Sphere
{
    [SerializeField]
    private float m_moveInputSpeed;
    
    public KeyboardInput MoveInput;
    
    private Vector3 m_moveDir;
    
    private void Awake() => MoveInput = new KeyboardInput(m_moveInputSpeed);
    
    public void Update()
    {
        m_moveDir = MoveInput.Update(m_moveDir);
    }
}

