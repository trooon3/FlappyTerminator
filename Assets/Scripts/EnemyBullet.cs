using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Terminator>())
        {
            TakeOffBullet();
        }
    }

    private void TakeOffBullet()
    {
        gameObject.SetActive(false);
    }
}
