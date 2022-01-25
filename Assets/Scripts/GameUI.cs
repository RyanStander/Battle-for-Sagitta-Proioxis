using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    bool isDisplayed = true;
    [SerializeField] GameObject respawnUI;
    [SerializeField] GameObject gameUI;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject playerStartPosition;

    private int _enemyTurretCount=1;
    private int _allyTurretCount=0;
    private void OnEnable()
    {        
        EventManager.onPlayerDeath +=ShowRespawnUI;
        EventManager.onPlayerRespawn += ShowGameUI;
        EventManager.onTurretSpawn += IncreaseTurretCount;
        EventManager.onTurretDestruct += DecreaseTurretCount;
    }
    private void OnDisable()
    {
        EventManager.onPlayerDeath -= ShowRespawnUI;
        EventManager.onPlayerRespawn -= ShowGameUI;
        EventManager.onTurretSpawn -= IncreaseTurretCount;
        EventManager.onTurretDestruct -= DecreaseTurretCount;
    }

    void ShowGameUI()
    {
        if (gameUI != null)
            gameUI.SetActive(true);
        if (respawnUI != null)
            respawnUI.SetActive(false);
        Instantiate(playerPrefab, playerStartPosition.transform.position, playerStartPosition.transform.rotation);
    }
    void ShowRespawnUI()
    {
        Invoke("DelayRespawnUIDisplay", 3);
    }

    public void RespawnButton()
    {
        EventManager.RespawnPlayer();
    }

    void DelayRespawnUIDisplay()
    {
        if (gameUI != null)
            gameUI.SetActive(false);
        if (respawnUI != null)
            respawnUI.SetActive(true);
        
    }
    public void IncreaseTurretCount(string turretTag)
    {
        if (turretTag == "Ally")
            _allyTurretCount++;
        if (turretTag == "Enemy")
            _enemyTurretCount++;
        //Debug.Log("Total enemy turrets: " + _enemyTurretCount + " Total ally turrets: " + _allyTurretCount);
    }
    public void DecreaseTurretCount(string turretTag)
    {
        if (turretTag == "Ally")
            _allyTurretCount--;
        if (turretTag == "Enemy")
            _enemyTurretCount--;
        //Debug.Log("Total enemy turrets: " + _enemyTurretCount + " Total ally turrets: " + _allyTurretCount);
        if (_enemyTurretCount == 0)
        {
            EventManager.AllTurretsDestroyed();
        }
    }
}
