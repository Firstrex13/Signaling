using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint1;
    [SerializeField] private Transform _targetPoint2;

    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint1.position, Time.deltaTime * _speed);

            if(transform.position == _targetPoint1.position)
            {
                _targetPoint1 = _targetPoint2;
            }        
        }
    }
}
