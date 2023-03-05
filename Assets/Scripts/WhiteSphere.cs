
using UnityEngine;

public class WhiteSphere : Sphere
{
    [SerializeField]
    private float m_moveInputSpeed;
    
    [SerializeField]
    private float m_forceMultiplier;
    
    public PlayerInput PlayerInput;
    
    private Vector3 m_moveDir;
    
    private void Awake() => PlayerInput = new PlayerInput(m_moveInputSpeed);
    
    public void Update()
    {
        m_moveDir = PlayerInput.Update(m_moveDir);
        
        if (Input.GetKeyDown(KeyCode.Space))
            Rigidbody.AddForce(m_moveDir * m_forceMultiplier, ForceMode.Impulse);
    }
}

