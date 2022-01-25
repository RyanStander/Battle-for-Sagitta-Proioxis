using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private int _score;

    //updates the score to tell player how many kills they got
    private void Start()
    {
        _scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EventManager.onAllyKilled+= DecreaseScore;
        EventManager.onEnemyKilled += IncreaseScore;
    }
    private void OnDisable()
    {
        EventManager.onAllyKilled -= DecreaseScore;
        EventManager.onEnemyKilled -= IncreaseScore;
    }
    private void IncreaseScore()
    {
        _score++;
        _scoreText.SetText("Kills: " + _score);
    }
    private void DecreaseScore()
    {
        _score--;
        _scoreText.SetText("Kills: " + _score);
    }
}
