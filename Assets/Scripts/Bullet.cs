using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] protected float _speed;
    
    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryGetComponent(out Terminator terminator) || TryGetComponent(out ScoreUpZone scoreZone))
        {
            return;
        }
        else
            TakeOffBullet();
    }

    private void TakeOffBullet()
    {
        gameObject.SetActive(false);
    }
}
