using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] float timeLimitSeconds=600;

    private TextMeshProUGUI _countdownText;
    private float _timer;
    private bool _gameOver = false;

    private void Start()
    {
        _countdownText = gameObject.GetComponent<TextMeshProUGUI>();
        _timer = Time.time;
    }

    private void Update()
    {
        //displays the timer so players know how long they have
        _timer += Time.deltaTime;
        float timeRemaining = timeLimitSeconds - _timer;
        string minutes = Mathf.Floor(timeRemaining / 60).ToString("00");
        string seconds = (timeRemaining % 60).ToString("00");
        
        if (timeRemaining < 0)
        {
            _countdownText.SetText("Time Remaining: 00:00");
            if (!_gameOver)
            {
                _gameOver = true;
                StaticValues.didWin = false;
                EventManager.MatchFinished();
            }
        }
        else
            _countdownText.SetText("Time Remaining: " + minutes + ":" + seconds);
    }
}
