using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private GameObject meleeAttackCollider;
    private PlayerInput inputActions;
    private InputAction meleeAttackAction;
    private float attackTimer = 0f;
    private float attackCooldown = 1.0f;

    void Awake()
    {
        inputActions = new PlayerInput();
        inputActions.Gameplay.Enable();
        meleeAttackAction = inputActions.FindAction("MeleeAttack");
    }

    void Update()
    {
        attackTimer = Mathf.Clamp(attackTimer + Time.deltaTime, 0f, attackCooldown);

        if (meleeAttackAction.WasPressedThisFrame() && attackTimer == attackCooldown)
        {
            StartCoroutine(Attack());
            attackTimer = 0f;
        }
    }

    private IEnumerator Attack()
    {
        meleeAttackCollider.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        meleeAttackCollider.SetActive(false);
    }
}
