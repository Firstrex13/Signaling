using System.Collections;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _signalingSound;

    [SerializeField] private float _speed = 0.5f;

    private Coroutine _coroutine;

    private float _targetVolume;

    private IEnumerator ChangeVolume(float target)
    {
        while (_signalingSound.volume != target)
        {
            _signalingSound.volume = Mathf.MoveTowards(_signalingSound.volume, target, Time.deltaTime * _speed);

            yield return null;
        }

        if (_signalingSound.volume == 0)
        {
            _signalingSound.Stop();

            StopCoroutine(_coroutine);

            _coroutine = null;
        }
    }

    public void StartSignal()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        else
        {
            _signalingSound.Play();

            _targetVolume = 1;

            _coroutine = StartCoroutine(ChangeVolume(_targetVolume));
        }
    }

    public void StopSignal()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _targetVolume = 0;

            _coroutine = StartCoroutine(ChangeVolume(_targetVolume));
        }
    }
}
