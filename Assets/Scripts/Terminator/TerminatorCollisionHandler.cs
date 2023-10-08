using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Terminator))]
public class TerminatorCollisionHandler : MonoBehaviour
{
    private Terminator _terminator;

    private void Start()
    {
        _terminator = GetComponent<Terminator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryGetComponent(out ScoreUpZone scoreZone))
        {
            _terminator.IncreaseScore();
        }
        else
        _terminator.Die();
    }
}
