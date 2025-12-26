using UnityEngine;

namespace Game.Combat
{
    public struct DamageResult
    {
        public float AppliedDamage;
        public bool WasFatal;

        public DamageResult(float appliedDamage, bool wasFatal)
        {
            AppliedDamage = appliedDamage;
            WasFatal = wasFatal;
        }
    }
}
