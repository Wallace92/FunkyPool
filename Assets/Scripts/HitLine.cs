using UnityEngine;

public class HitLine : MonoBehaviour
{
    private LineRenderer m_lineRenderer;
    private WhiteSphere m_whiteSphere;
    private void Awake()
    {
        m_lineRenderer = GetComponentInChildren<LineRenderer>();
        m_whiteSphere = GetComponent<WhiteSphere>();
    }

    private void Start() => m_whiteSphere.MoveInput.MoveDirChanged += DrawLine;

    private void OnDestroy() => m_whiteSphere.MoveInput.MoveDirChanged -= DrawLine;

    private void DrawLine(Vector3 moveDir)
    {
        var position = transform.position;
        
        Vector3[] positions = new Vector3[] {position, position + moveDir};
        
        m_lineRenderer.SetPositions(positions);
    }
}