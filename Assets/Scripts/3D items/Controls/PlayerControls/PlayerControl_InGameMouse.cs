using UnityEngine;
using UnityEngine.AI;

public class PlayerControl_InGameMouse : MonoBehaviour, IPlayerControl
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public const IPlayerControl.eControllerType PLAYER_CONTROLLER_TYPE = IPlayerControl.eControllerType.inGameMouse;
    private NavMeshAgent agent;
    [SerializeField] LayerMask layerMask;

    private InputSystem_Actions input;

    private void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>(true);
        input = new InputSystem_Actions();
        input.Mouse.Move.performed += ctx => Move();
    }

    private void OnEnable()
    {
        input.Enable();
        agent.enabled = true;
    }

    private void OnDisable()
    {
        input.Disable();
        agent.enabled = false;
    }

    private void Move()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50f, layerMask)) 
        { 
            agent.destination = hit.point;
        }
    }

    #region interface
    public string RetrieveDirectionString()
    {
        throw new System.NotImplementedException();
    }

    public IPlayerControl.eControllerType GetControllerType()
    {
        return PLAYER_CONTROLLER_TYPE;
    }

    public void SetPlayerControlActivity(bool isActive)
    {
        agent.enabled = isActive;
        this.enabled = isActive;
    }
    #endregion //interface
}
