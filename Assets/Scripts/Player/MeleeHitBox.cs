using System;
using UnityEngine;

public class MeleeHitBox : MonoBehaviour
{
    public event Action<DamageReceiver> OnDamageReceiverCollision;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<DamageReceiver>(out DamageReceiver damageReceiver))
        {
            OnDamageReceiverCollision.Invoke(damageReceiver);
        }
    }
}
