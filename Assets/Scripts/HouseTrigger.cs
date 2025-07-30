using System;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    public Action EnemyCameIn;
    public Action EnemyWentOut;

    private void OnTriggerEnter(Collider other)
    {
        EnemyCameIn?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyWentOut?.Invoke();
    }
}
