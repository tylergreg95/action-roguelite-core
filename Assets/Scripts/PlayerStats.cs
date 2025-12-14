using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public enum StatType
    {
        MoveSpeed
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

    /* BASE PLAYER STATS */
    private float movementSpeed = 5f;


    /* BASE STAT MODIFIERS */
    private List<StatModifier> movementSpeedModifiers = new List<StatModifier>();

    public float GetStat(StatType statType)
    {
        switch (statType)
        {
           case StatType.MoveSpeed:
                return CalculateFinalStat(movementSpeed, movementSpeedModifiers);
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
