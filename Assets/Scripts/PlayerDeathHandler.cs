using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<Health>().OnDeath += DeathSequence;
    }

    void OnDisable()
    {
        GetComponent<Health>().OnDeath -= DeathSequence;
    }

    private void DeathSequence()
    {
        //placeholder behavior for now until more systems are put in place
        Destroy(gameObject);
    }
}
