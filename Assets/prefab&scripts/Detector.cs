using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    public event UnityAction Entered;
    public event UnityAction Exited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            Entered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            Exited?.Invoke();
        }
    }
}