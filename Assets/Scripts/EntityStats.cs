using System;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public enum StatType
    {
        MoveSpeed,
        MaxHealth
    }

    public enum ModifierType
    {
        Additive,
        Multiplicative
    }

    public struct StatModifier
    {
        public ModifierType operation;
        public float magnitude;

        public StatModifier(ModifierType operation, float magnitude)
        {
            this.operation = operation;
            this.magnitude = magnitude;
        }
    }

    public event Action<StatType> OnModifierAltered;

    /* BASE PLAYER STATS */
    private float movementSpeed = 5f;
    private float maxHealth = 10f;


    /* BASE STAT MODIFIERS */
    private List<StatModifier> movementSpeedModifiers = new List<StatModifier>();
    private List<StatModifier> maxHealthModifiers = new List<StatModifier>();

    public float GetStat(StatType statType)
    {
        switch (statType)
        {
           case StatType.MoveSpeed:
                return CalculateFinalStat(movementSpeed, movementSpeedModifiers);
            case StatType.MaxHealth:
                return CalculateFinalStat(maxHealth, maxHealthModifiers);
            default:
                Debug.LogError($"Unhandled StatType: {statType}");
                return 0f; 
        } 
    }

    public void AddModifier(StatType statType, StatModifier statModifier)
    {
        switch (statType)
        {
            case StatType.MoveSpeed:
                movementSpeedModifiers.Add(statModifier);
                OnModifierAltered?.Invoke(StatType.MoveSpeed);
                return;
            case StatType.MaxHealth:
                maxHealthModifiers.Add(statModifier);
                OnModifierAltered?.Invoke(StatType.MaxHealth);
                return;
            default:
                Debug.LogError($"Unhandled StatType: {statType}");
                return; 
        }
    }

    private float CalculateFinalStat(float baseValue, List<StatModifier> modifiers)
    {
        float finalValue = baseValue;

        foreach (StatModifier modifier in modifiers)
        {
            if(modifier.operation == ModifierType.Additive)
            {
                finalValue += modifier.magnitude;
            }
        }

        foreach (StatModifier modifier in modifiers)
        {
            if(modifier.operation == ModifierType.Multiplicative)
            {
                finalValue *= modifier.magnitude;
            }
        }


        return finalValue;
    }

}
