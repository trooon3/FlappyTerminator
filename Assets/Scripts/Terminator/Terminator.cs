using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TerminatorMover))]
public class Terminator : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletStartPosition;
    private TerminatorMover _mover;
    private int _score = 0;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _mover = GetComponent<TerminatorMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Shoot(_bullet);
        }
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetTerminator();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    private void Shoot(Bullet bullet)
    {
        Instantiate(_bullet, _bulletStartPosition.position, transform.rotation);
    }

    public  void Die()
    {
        GameOver?.Invoke();
    }
}
