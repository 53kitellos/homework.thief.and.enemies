using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Detector _detector;

    public void OnEnable()
    {
        _detector.Entered += Play;
        _detector.Exited += Stop;
    }

    public void OnDisable()
    {
        _detector.Entered -= Play;
        _detector.Exited -= Stop;
    }

    public void Play()
    {
        _audioSource.Play();
        _audioSource.DOFade(1,5);
    }

    public void Stop()
    {
        Tween tween = _audioSource.DOFade(0, 3);
        tween.OnComplete(() => _audioSource.Stop());
    }
}