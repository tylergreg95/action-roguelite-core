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
    private PlayerState playerState;

    void Awake()
    {
        inputActions = new PlayerInput();
        inputActions.Gameplay.Enable();
        meleeAttackAction = inputActions.FindAction("MeleeAttack");
        playerState = GetComponent<PlayerState>();
    }

    void Update()
    {
        attackTimer = Mathf.Clamp(attackTimer + Time.deltaTime, 0f, attackCooldown);

        if (meleeAttackAction.WasPressedThisFrame() && attackTimer == attackCooldown && playerState.GetCanAct())
        {
            StartCoroutine(Attack());
            attackTimer = 0f;
        }
    }

    private IEnumerator Attack()
    {
        playerState.SetCanAct(false);
        meleeAttackCollider.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        meleeAttackCollider.SetActive(false);
        playerState.SetCanAct(true);
    }
}
