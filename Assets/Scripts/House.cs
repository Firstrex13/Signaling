using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signal _signal;
    [SerializeField] private HouseTrigger _trigger;

    private void OnEnable()
    {
        _trigger.EnemyCameIn += _signal.StartSignal;
        _trigger.EnemyWentOut += _signal.StopSignal;
    }

    private void OnDisable()
    {
        _trigger.EnemyCameIn -= _signal.StartSignal;
        _trigger.EnemyWentOut -= _signal.StopSignal;
    }
}
