using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Terminator _terminator;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void Start()
    {
        Time.timeScale = 0;
        _gameOverScreen.Close();
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _terminator.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _terminator.GameOver -= OnGameOver;
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _enemySpawner.ResetPool();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        _terminator.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
