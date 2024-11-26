using UnityEngine;

public class PlayerControl_Keyboard : MonoBehaviour, IPlayerControl
{
    public const IPlayerControl.eControllerType PLAYER_CONTROLLER_TYPE = IPlayerControl.eControllerType.keyboard;
    private Movement movement;
    private IPlayerControl.eControlDirection m_direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        movement = GetComponentInParent<Movement>();
        m_direction = IPlayerControl.eControlDirection.none;
    }

    private void OnEnable()
    {
        m_direction = IPlayerControl.eControlDirection.none;        
    }

    private void OnDisable()
    {
        m_direction = IPlayerControl.eControlDirection.none;        
    }
      
    void Update()
    {
        // Press down key  --> enable movement
        // release key --> disable movement

        // TRANSLATION
        // up
        if (Input.GetKeyDown(KeyCode.W)) m_direction |= IPlayerControl.eControlDirection.up;
        if (Input.GetKeyUp(KeyCode.W)) m_direction = m_direction &~ IPlayerControl.eControlDirection.up;
        // down
        if (Input.GetKeyDown(KeyCode.S)) m_direction |= IPlayerControl.eControlDirection.down;
        if (Input.GetKeyUp(KeyCode.S)) m_direction = m_direction & ~IPlayerControl.eControlDirection.down;
        // left
        if (Input.GetKeyDown(KeyCode.A)) m_direction |= IPlayerControl.eControlDirection.left;
        if (Input.GetKeyUp(KeyCode.A)) m_direction = m_direction & ~IPlayerControl.eControlDirection.left;
        // right
        if (Input.GetKeyDown(KeyCode.D)) m_direction |= IPlayerControl.eControlDirection.right;
        if (Input.GetKeyUp(KeyCode.D)) m_direction = m_direction & ~IPlayerControl.eControlDirection.right;

        // ROTATION
        // CW
        if (Input.GetKeyDown(KeyCode.RightArrow)) m_direction |= IPlayerControl.eControlDirection.rotateCW;
        if (Input.GetKeyUp(KeyCode.RightArrow)) m_direction = m_direction & ~IPlayerControl.eControlDirection.rotateCW;
        // CCW
        if (Input.GetKeyDown(KeyCode.LeftArrow)) m_direction |= IPlayerControl.eControlDirection.rotateCCW;
        if (Input.GetKeyUp(KeyCode.LeftArrow)) m_direction = m_direction & ~IPlayerControl.eControlDirection.rotateCCW;
        // UP
        if (Input.GetKeyDown(KeyCode.DownArrow)) m_direction |= IPlayerControl.eControlDirection.rotateUp;
        if (Input.GetKeyUp(KeyCode.DownArrow)) m_direction = m_direction & ~IPlayerControl.eControlDirection.rotateUp;
        // DOWN
        if (Input.GetKeyDown(KeyCode.UpArrow)) m_direction |= IPlayerControl.eControlDirection.rotateDown;
        if (Input.GetKeyUp(KeyCode.UpArrow)) m_direction = m_direction & ~IPlayerControl.eControlDirection.rotateDown;

        movement.ApplyMovement(m_direction);
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
        this.enabled = isActive;
    }
    #endregion //interface
}
