using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private Transform _enemy;

    [SerializeField] private float _repeateRate;

    private void Start()
    {
        StartCoroutine(CreateBullet());
    }

    private IEnumerator CreateBullet()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_repeateRate);

        while (enabled)
        {
            var direction = (_enemy.position - transform.position).normalized;

            var bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.transform.up = direction;

            bullet.Rigidbody.linearVelocity = direction * _speed;

            yield return waitForSeconds;
        }
    }
}