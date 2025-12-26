using UnityEngine;

namespace Game.Combat
{
    public struct DamageIntent
    {
        public float Amount;
        public GameObject Source;

        public DamageIntent(float amount, GameObject source)
        {
            Amount = amount;
            Source = source;
        }
    }
}
