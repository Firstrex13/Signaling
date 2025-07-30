using System;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    public Action EnemyCameIn;
    public Action EnemyWentOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyMover>(out _))
        {
            EnemyCameIn?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<EnemyMover>(out _))
        {
            EnemyWentOut?.Invoke();
        }
    }
}
