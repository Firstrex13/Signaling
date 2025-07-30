using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signalingSound;
    [SerializeField] private float _speed = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyMover>(out _))
            _signalingSound.Play();
        StartCoroutine(IncreaseVolume());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<EnemyMover>(out _))
            StartCoroutine(DecreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        float currentVolume = 0f;
        float targetVolume = 1f;

        _signalingSound.volume = currentVolume;

        while (currentVolume < targetVolume)
        {
            currentVolume = Mathf.MoveTowards(currentVolume, targetVolume, Time.deltaTime * _speed);

            _signalingSound.volume = currentVolume;

            yield return null;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        float currentVolume = 1f;
        float targetVolume = 0f;

        _signalingSound.volume = currentVolume;

        while (currentVolume > targetVolume)
        {
            currentVolume = Mathf.MoveTowards(currentVolume, targetVolume, Time.deltaTime * _speed);

            _signalingSound.volume = currentVolume;

            yield return null;
        }

        if(currentVolume == targetVolume)
        {
            _signalingSound.Stop();
        }
    }
}
