using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float currentHealth;
    private bool isDead;
    private EntityStats entityStats;

    void Awake()
    {
        entityStats = GetComponent<EntityStats>();
        InitializeToMax();
        isDead = false;
    }

    private void MaxHealthChanged(EntityStats.StatType statType)
    {
        if(statType == EntityStats.StatType.MaxHealth)
        {
            ModifyCurrentHealth(0);
        }
    }

    private void OnEnable()
    {
        entityStats.OnModifierAltered += MaxHealthChanged;
    }

    private void OnDisable()
    {
        entityStats.OnModifierAltered -= MaxHealthChanged;
    }

    public void ModifyCurrentHealth (float delta)
    {
        currentHealth = Mathf.Clamp(currentHealth + delta, 0, entityStats.GetStat(EntityStats.StatType.MaxHealth));

        if (currentHealth == 0 && !isDead)
        {   
            isDead = true;
        }
    }

    private void InitializeToMax()
    {
        currentHealth = entityStats.GetStat(EntityStats.StatType.MaxHealth);
    }

}
