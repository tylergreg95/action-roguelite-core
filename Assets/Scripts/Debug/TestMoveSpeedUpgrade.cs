using UnityEngine;
using UnityEngine.InputSystem;

public class TestMoveSpeedUpgrade : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    PlayerInput inputActions;
    InputAction addModifierAction;

    void Awake()
    {
        inputActions = new PlayerInput();
        addModifierAction = inputActions.FindAction("AddModifier");
        inputActions.Debug.Enable();
    }

    void Update()
    {
        if (addModifierAction.WasPressedThisFrame())
        {
            AddModifierToPlayer();
            Debug.Log("Added move speed modifier to player");
        }
    }

    void AddModifierToPlayer()
    {
        PlayerStats.StatModifier statModifier = new PlayerStats.StatModifier(
            PlayerStats.ModifierType.Additive,
            5f
        );

        playerStats.AddModifier(PlayerStats.StatType.MoveSpeed, statModifier);
    }
}
