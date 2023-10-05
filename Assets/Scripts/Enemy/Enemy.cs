using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletStartPosition;

    public Terminator Terminator { get; private set; }

    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            Instantiate(_bullet, _bulletStartPosition.position, transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyBullet>())
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
