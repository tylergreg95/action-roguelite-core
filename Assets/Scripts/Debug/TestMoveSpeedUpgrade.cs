using UnityEngine;
using UnityEngine.InputSystem;

public class TestMoveSpeedUpgrade : MonoBehaviour
{
    [SerializeField] private EntityStats entityStats;
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
        EntityStats.StatModifier statModifier = new EntityStats.StatModifier(
            EntityStats.ModifierType.Additive,
            5f
        );

        entityStats.AddModifier(EntityStats.StatType.MoveSpeed, statModifier);
    }
}
