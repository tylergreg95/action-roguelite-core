using UnityEngine;

public class MeleeHitBox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Hitbox collided with {other.gameObject.name}");
    }
}
