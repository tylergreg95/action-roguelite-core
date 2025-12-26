using Game.Combat;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestDamageReceiver : MonoBehaviour
{
    [SerializeField] DamageReceiver damageReceiver;
    PlayerInput inputActions;
    InputAction doDamageAction;

    void Awake()
    {
        inputActions = new PlayerInput();
        doDamageAction = inputActions.FindAction("DoDamage");
        inputActions.Debug.Enable();
    }
                                                                                                           
    void Update()
    {
        if (doDamageAction.WasPressedThisFrame())
        {
            DamageIntent damageIntent = new DamageIntent(1f, this.gameObject);
            Debug.Log($"DAMAGE INTENT: {this.gameObject.name} sending {damageIntent.Amount} damage to {damageReceiver.gameObject.name}");
            DamageResult result = damageReceiver.ReceiveDamage(damageIntent);
            Debug.Log($"DAMAGE RESULT: {damageReceiver.gameObject.name} took {result.AppliedDamage} damage. Damage was fatal: {result.WasFatal}");
        }
    }
}
