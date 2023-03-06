using UnityEngine;

public class WhiteSphere : Sphere
{
    public TurnPresenter TurnPresenter;

    [SerializeField]
    private float m_moveInputSpeed;

    [SerializeField]
    private float m_forceMultiplier;


    public PlayerInput PlayerInput;
    
    private GameManager m_gameManager;
    
    private Vector3 m_moveDir;
    
    private new void Awake()
    {
        base.Awake();
        PlayerInput = new PlayerInput(m_moveInputSpeed);
        
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
        if (!m_gameManager.SpheresDontMove)
            return;
        
        m_moveDir = PlayerInput.Update(m_moveDir);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(m_moveDir * m_forceMultiplier, ForceMode.Impulse);
            PlayerInput.RestartMoveDir();
            TurnPresenter.IncreaseTurn(1);
        }
    }
}

