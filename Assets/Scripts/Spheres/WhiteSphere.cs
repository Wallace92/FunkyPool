using System.Collections;
using UnityEngine;

public class WhiteSphere : Sphere
{
    public TurnPresenter TurnPresenter;

    [SerializeField]
    private float m_moveInputSpeed;

    [SerializeField]
    private float m_forceMultiplier;
    
    [SerializeField]
    private float m_forceMaximum;

    public PlayerInput PlayerInput;
    
    private GameManager m_gameManager;
    
    private Vector3 m_moveDir;
    
    private bool m_stopMovement;
    
    private new void Awake()
    {
        base.Awake();
        PlayerInput = new PlayerInput(m_moveInputSpeed, m_forceMaximum);
        
        if (TurnPresenter == null)
            Debug.LogError($"Assign {TurnPresenter} to WhiteSphere");
    }

    public void Constructor(GameManager gameManager, int maxTurnNumber)
    {
        m_gameManager = gameManager;
        TurnPresenter.Constructor(maxTurnNumber);
    }

    public void Update()
    {
        if (!m_gameManager.SpheresDontMove || m_gameManager.LevelCompleted)
            return;
        
        m_moveDir = PlayerInput.Update(m_moveDir);

        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(StartMovementRoutine());
        
        if (m_stopMovement)
        {
            TurnPresenter.IncreaseTurn(1);
            m_stopMovement = false;
        }
    }

    private IEnumerator StartMovementRoutine()
    {
        Rigidbody.AddForce(m_moveDir * m_forceMultiplier, ForceMode.Impulse);
        PlayerInput.RestartMoveDir();
        m_moveDir = Vector3.zero;
        
        yield return new WaitForFixedUpdate();
        m_stopMovement = true;
    }
}

