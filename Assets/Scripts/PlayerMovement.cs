using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMovement : MonoBehaviour
{
    public enum MovementState
    {
        Idle,
        Running
    }

    [SerializeField] private GameObject playerModel;

    private MovementState currentMovementState;
    private PlayerInput inputActions;
    private CharacterController characterController;
    private PlayerStats playerStats;

    void Awake()
    {
        inputActions = new PlayerInput();
        inputActions.Gameplay.Enable();
        characterController = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        Vector2 movementDirection = inputActions.Gameplay.Move.ReadValue<Vector2>();

        if (movementDirection.magnitude > 0)
        {
            // movement intent exists
            ChangeMovementState(MovementState.Running);
            
            //now move the character
            Vector3 worldSpaceDirection = new Vector3(movementDirection.x, 0, movementDirection.y);
            worldSpaceDirection.Normalize();
            RotatePlayerModel(worldSpaceDirection);
            characterController.Move(worldSpaceDirection * playerStats.GetStat(PlayerStats.StatType.MoveSpeed) * Time.deltaTime);
        } else
        {
            ChangeMovementState(MovementState.Idle);
        }
    }

    public MovementState GetCurrentMovementState()
    {
        return currentMovementState;
    }

    private void ChangeMovementState(MovementState state)
    {
        if (currentMovementState != state)
        {
            currentMovementState = state;
        }
    }

    private void RotatePlayerModel(Vector3 directionToFace)
    {
        playerModel.transform.forward = directionToFace;
    }

    void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }
}
