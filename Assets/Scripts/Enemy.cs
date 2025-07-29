using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _points;

    [SerializeField] private Transform _mainPoint;

    private int _pointCount;

    private void Update()
    {
        Transform pointPosition = _points[_pointCount];

        transform.position = Vector3.MoveTowards(transform.position, pointPosition.position, _speed * Time.deltaTime);

        if (transform.position == pointPosition.position)
        {
            SetNextPointPosition();
        }
    }

    private void SetNextPointPosition()
    {
        _pointCount++;

        if (_pointCount == _points.Length)
        {
            _pointCount = 0;
        }

        Vector3 aimPoint = _points[_pointCount].transform.position;

        transform.forward = aimPoint - transform.position;
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _points = new Transform[_mainPoint.childCount];

        for (int i = 0; i < _mainPoint.childCount; i++)
        {
            _points[i] = _mainPoint.GetChild(i).GetComponent<Transform>();
        }
    }
#endif
}