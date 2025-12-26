using Game.Combat;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
    }

    public DamageResult RecieveDamage(DamageIntent damageIntent)
    {
        float healthBeforeDamageApplication = health.GetCurrentHealth();
        float intendedDamage = damageIntent.Amount;

        health.ModifyCurrentHealth(-intendedDamage);

        float healthAfterDamageApplication = health.GetCurrentHealth();
        
        DamageResult result = new DamageResult(healthBeforeDamageApplication -  healthAfterDamageApplication, health.GetIsDead());

        return result;
    }
}
