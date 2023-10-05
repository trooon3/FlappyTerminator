using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Terminator _terminator;

    private void OnEnable()
    {
        _terminator.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _terminator.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}
