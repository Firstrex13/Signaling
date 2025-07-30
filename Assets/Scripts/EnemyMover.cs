using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;

    [SerializeField] private float _speed;

    private float _distanceToTarget = 0.1f;

    private int _pointIndex;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (IsTargetReached())
        {
            GetIndex();
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPoints[_pointIndex].position, Time.deltaTime * _speed);       
    }

    private float GetSqrDistance(Vector3 start, Vector3 end)
    {
        return (end - start).sqrMagnitude;
    }

    private bool IsEnoughClose(Vector3 start, Vector3 end, float distance)
    {
        return GetSqrDistance(start, end) <= distance * distance;
    }

    public bool IsTargetReached()
    {
        return IsEnoughClose(transform.position, _targetPoints[_pointIndex].position, _distanceToTarget);
    }

    private int GetIndex()
    {
       return _pointIndex = ++_pointIndex % _targetPoints.Length;
    }
}
