using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Objectives : MonoBehaviour
{
    //private Text _objective;
    private TextMeshProUGUI _objective;
    private int _objectiveIndex=0;
    private void Start()
    {
        _objective = gameObject.GetComponent<TextMeshProUGUI>();
        Debug.Log(_objective.name);
    }
    void OnEnable()
    {
        EventManager.onAllTurretsDestroyed += FirstObjectiveComplete;
        EventManager.onEnemyCarrierDestroyed += GameVictory;
        EventManager.onMatchFinished += GoToEndScreen;
        EventManager.onAllyCarrierDestroyed += PlayerLost;
    }
    void OnDisable()
    {
        EventManager.onAllTurretsDestroyed -= FirstObjectiveComplete;
        EventManager.onEnemyCarrierDestroyed -= GameVictory;
        EventManager.onMatchFinished -= GoToEndScreen;
        EventManager.onAllyCarrierDestroyed -= PlayerLost;
    }
    private void FirstObjectiveComplete()
    {
        _objectiveIndex = 1;
        UpdateObjective();
    }
    private void GameVictory()
    {
        _objectiveIndex = 2;
        UpdateObjective();
    }
    public void UpdateObjective()
    {
        switch (_objectiveIndex)
        {
            case 0:
                _objective.SetText("Take out the enemy carrier turrets");
                break;
            case 1:
                _objective.SetText("Destroy the enemy carrier");
                break;
            case 2:
                _objective.SetText("We won this battle, good job soldier");
                break;
        }
    }
    void GoToEndScreen()
    {
        Invoke("DelayGoToEndScreen", 3);
    }
    void DelayGoToEndScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
    }
    void PlayerLost()
    {

    }
}
