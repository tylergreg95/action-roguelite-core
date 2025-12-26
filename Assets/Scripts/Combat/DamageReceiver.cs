using Game.Combat;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
    }

    public DamageResult ReceiveDamage(DamageIntent damageIntent)
    {
        float healthBeforeDamageApplication = health.GetCurrentHealth();
        float intendedDamage = damageIntent.Amount;

        health.ModifyCurrentHealth(-intendedDamage);

        float healthAfterDamageApplication = health.GetCurrentHealth();
        float appliedDamage = healthBeforeDamageApplication -  healthAfterDamageApplication;

        DamageResult result = new DamageResult(appliedDamage, health.GetIsDead() && appliedDamage > 0);

        return result;
    }
}
