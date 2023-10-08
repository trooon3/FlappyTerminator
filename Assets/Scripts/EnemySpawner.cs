using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _delay;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _maxSpawnPositionY;
    
    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _delay)
        {
            if (TryGetObgect(out GameObject enemy))
            {
                _elapsedTime = 0;

                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPosition = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                
                enemy.SetActive(true);
                enemy.transform.position = spawnPosition;

                DisableObjectAbroadScreen();
            }
        }
    }

}
