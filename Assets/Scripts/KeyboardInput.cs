using UnityEngine;

public class KeyboardInput : IMoveInput
{
    public KeyboardInput(float movementChange) => m_movementChange = movementChange;

    private readonly float m_movementChange;
    
    private float m_x;
    private float m_y;
    
    public float Vertical()
    {
        if (Input.GetKey(KeyCode.S))
            m_y -= m_movementChange * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
            m_y += m_movementChange * Time.deltaTime;
        
        return m_y;
    }

    public float Horizontal()
    {
        if (Input.GetKey(KeyCode.A))
            m_x -= m_movementChange * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            m_x += m_movementChange * Time.deltaTime;
        
        return m_x;
    }
}