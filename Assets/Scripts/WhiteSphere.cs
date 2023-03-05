using UnityEngine;

public class WhiteSphere : Sphere
{
    [SerializeField]
    private float m_moveInputSpeed;
    
    private IMoveInput m_moveInput;

    private Vector3 m_moveDir = Vector3.zero;

    private LineRenderer m_lineRenderer;

    private void Awake()
    {
        m_moveInput = new KeyboardInput(m_moveInputSpeed);
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        var x = m_moveInput.Horizontal();
        var y = m_moveInput.Vertical();
        
        m_moveDir = new Vector3(x, 0, y);
        DrawLine();
    }

    private void DrawLine()
    {
        var startPos = transform.position;
        var endPos = transform.position + m_moveDir;
        Vector3[] positions = new Vector3[] {startPos, endPos};
        
        m_lineRenderer.SetPositions(positions);
    }
}