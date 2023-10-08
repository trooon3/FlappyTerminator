using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletStartPosition;
    private WaitForSeconds _shootDelay = new WaitForSeconds(2f);
    public Terminator Terminator { get; private set; }

    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        yield return _shootDelay;

        while (true)
        {
            Instantiate(_bullet, _bulletStartPosition.position, transform.rotation);
            yield return _shootDelay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryGetComponent(out EnemyBullet bullet))
        {
            return;
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
