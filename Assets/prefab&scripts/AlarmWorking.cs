using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;

public class AlarmWorking : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _audioSource.Play();
            _audioSource.DOFade(1,1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _audioSource.DOFade(0,1);
        }
    }
}
