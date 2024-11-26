using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl_Xbox : MonoBehaviour, IPlayerControl
{
    public const IPlayerControl.eControllerType PLAYER_CONTROLLER_TYPE = IPlayerControl.eControllerType.xbox;
    public const float XBOX_CONTROLLER_TRESHOLD = 0.2f;
    private InputSystem_Actions input;
    private Movement movement;

    private void Awake()
    {
        input = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        input.Playing.Fire.performed += Fire;
        input.Enable();
    }

    private void OnDisable()
    {
        input.Playing.Fire.performed -= Fire;
        input.Disable();
    }

    public void Update()
    {
        if (!movement) return;

        // update le vecteur direction
        Vector2 inputDirection = new Vector2();
        inputDirection = input.Playing.Move.ReadValue<Vector2>();
        if (inputDirection.magnitude < XBOX_CONTROLLER_TRESHOLD) inputDirection = Vector2.zero;

        // update le vecteur rotation
        Vector2 inputRotation = new Vector2();
        inputRotation = input.Playing.LookAround.ReadValue<Vector2>();
        if (inputRotation.magnitude < XBOX_CONTROLLER_TRESHOLD) inputRotation = Vector2.zero;

        if (inputDirection.magnitude == 0 && inputRotation.magnitude == 0) return;

        // ok on execute.  Movement detecte.
        Vector3 inputDirectionV3 = new Vector3(inputDirection.x, 0f, inputDirection.y);
        Vector3 inputRotationV3 = new Vector3(0f, inputRotation.x, inputRotation.y);

        //Debug.Log($"InputDirection v3 = {inputDirectionV3} , inputRotation = {inputRotation}");
        movement.ApplyMovement(inputDirectionV3, inputRotationV3);
    }
    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Boum  --> Fire !");
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
        if (isActive == true && movement == null) movement = GetComponentInParent<Movement>();
        this.enabled = isActive;
    }
    #endregion //interface

}
