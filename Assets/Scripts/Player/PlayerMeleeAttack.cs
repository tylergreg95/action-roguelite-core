using System.Collections;
using Game.Combat;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private GameObject meleeAttackCollider;
    [SerializeField] private MeleeHitBox meleeHitBox;
    private PlayerInput inputActions;
    private InputAction meleeAttackAction;
    private float attackTimer = 0f;
    private float attackCooldown = 1.0f;
    private PlayerState playerState;
    private EntityStats entityStats;

    void Awake()
    {
        inputActions = new PlayerInput();
        inputActions.Gameplay.Enable();
        meleeAttackAction = inputActions.FindAction("MeleeAttack");
        playerState = GetComponent<PlayerState>();
        entityStats = GetComponent<EntityStats>();
    }

    void OnEnable()
    {
        meleeHitBox.OnDamageReceiverCollision += SendDamageIntent;
    }

    void OnDisable()
    {
        meleeHitBox.OnDamageReceiverCollision -= SendDamageIntent;
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

    private void SendDamageIntent(DamageReceiver damageReceiver)
    {
        //placeholder raw damage number until we implement an EntityStat for it (and probably a weapon stat system)
        DamageIntent damageIntent = new DamageIntent(entityStats.GetStat(EntityStats.StatType.MeleeDamage), gameObject);
        damageReceiver.ReceiveDamage(damageIntent);
    }
}
