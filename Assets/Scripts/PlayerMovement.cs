using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public enum MovementState
    {
        IDLE,
        RUNNING
    }

    [SerializeField] private GameObject playerModel;

    private MovementState currentMovementState;
    private float movementSpeed = 5.0f; // replace with player stats once they exist
    private PlayerInput inputActions;
    private CharacterController characterController;

    void Awake()
    {
        inputActions = new PlayerInput();
        inputActions.Gameplay.Enable();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 movementDireciton = inputActions.Gameplay.Move.ReadValue<Vector2>();

        if (movementDireciton.magnitude > 0)
        {
            // movement intent exists
            ChangeMovementState(MovementState.RUNNING);
            
            //now move the character
            Vector3 worldSpaceDireciton = new Vector3(movementDireciton.x, 0, movementDireciton.y);
            worldSpaceDireciton.Normalize();
            RotatePlayerModel(worldSpaceDireciton);
            characterController.Move(worldSpaceDireciton * movementSpeed * Time.deltaTime);
        } else
        {
            ChangeMovementState(MovementState.IDLE);
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
