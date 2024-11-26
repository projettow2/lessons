using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float m_translationSpeed;
    [SerializeField] private float m_rotationSpeed;

    private void Awake()
    {
        if (TryGetComponent<UnityEngine.AI.NavMeshAgent>(out UnityEngine.AI.NavMeshAgent navMeshAgent))
        {
            navMeshAgent.enabled = false;
        }
    }

    public void SetPlayerControlActivity(IPlayerControl.eControllerType type, bool isActive)
    {
        IPlayerControl[] playerControls = GetComponentsInChildren<IPlayerControl>(true);
        foreach (IPlayerControl pc in playerControls)
        {
            if (pc.GetControllerType() == type)
            {
                pc.SetPlayerControlActivity(isActive);
            }
        }
    }
    public void ApplyMovement(IPlayerControl.eControlDirection eDirection)
    {
        if (eDirection == IPlayerControl.eControlDirection.none) return;

        Vector3 translation = Vector3.zero;
        if ((eDirection & IPlayerControl.eControlDirection.HasTranslation) != 0)
        {
            if ((eDirection & IPlayerControl.eControlDirection.up) != 0) translation += Vector3.forward;
            if ((eDirection & IPlayerControl.eControlDirection.down) != 0) translation -= Vector3.forward;
            if ((eDirection & IPlayerControl.eControlDirection.left) != 0) translation += Vector3.left;
            if ((eDirection & IPlayerControl.eControlDirection.right) != 0) translation -= Vector3.left;
        }

        Vector3 rotation = Vector3.zero;
        if ((eDirection & IPlayerControl.eControlDirection.HasRotation) != 0)
        {
            if ((eDirection & IPlayerControl.eControlDirection.rotateCW) != 0) rotation += Vector3.up;
            if ((eDirection & IPlayerControl.eControlDirection.rotateCCW) != 0) rotation -= Vector3.up;
            if ((eDirection & IPlayerControl.eControlDirection.rotateUp) != 0) rotation += Vector3.left;
            if ((eDirection & IPlayerControl.eControlDirection.rotateDown) != 0) rotation -= Vector3.left;
        }

        ApplyMovement(translation.normalized, rotation);
    }
    public void ApplyMovement(Vector3 direction, Vector3 rotation)
    {
        Quaternion relativeRotation = Quaternion.Euler(rotation * Time.deltaTime * m_rotationSpeed);
        transform.rotation *= relativeRotation;

        Vector3 worldDirection = transform.TransformDirection(direction * Time.deltaTime * m_translationSpeed);
        transform.position += worldDirection;
    }
}
