using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpZone : MonoBehaviour
{
    public Terminator Terminator { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryGetComponent(out Terminator terminator))
        {
          Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
