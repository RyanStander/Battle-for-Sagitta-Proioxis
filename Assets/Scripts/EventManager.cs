using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //class is used to give interaction between different classes without the need to link any of them
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;

    public delegate void TakeDamageDelegate(float amount);
    public static TakeDamageDelegate onTakeDamage;

    public delegate void PlayerDiesDelegate();
    public static PlayerDiesDelegate onPlayerDeath;

    public delegate void PlayerRespawnDelegate();
    public static PlayerRespawnDelegate onPlayerRespawn;

    public delegate void TurretSpawnedDelegate(string turretTag);
    public static TurretSpawnedDelegate onTurretSpawn;

    public delegate void TurretDestroyedDelegate(string turretTag);
    public static TurretDestroyedDelegate onTurretDestruct;

    public delegate void AllTurretsDestroyedDelegate();
    public static AllTurretsDestroyedDelegate onAllTurretsDestroyed;

    public delegate void EnemyCarrierDestroyedDelegate();
    public static EnemyCarrierDestroyedDelegate onEnemyCarrierDestroyed;

    public delegate void AllyCarrierDestroyedDelegate();
    public static AllyCarrierDestroyedDelegate onAllyCarrierDestroyed;

    public delegate void MatchFinishedDelegate();
    public static MatchFinishedDelegate onMatchFinished;

    public delegate void EnemyKilledDelegate();
    public static EnemyKilledDelegate onEnemyKilled;

    public delegate void AllyKilledDelegate();
    public static AllyKilledDelegate onAllyKilled;

    public static void StartGame()
    {
        Debug.Log("Game has been started");
        onStartGame?.Invoke();
    }
    public static void TakeDamage(float percent)
    {
        //Debug.Log("Take damage: "+percent);
        onTakeDamage?.Invoke(percent);

    }

    public static void PlayerDeath()
    {
        //Debug.Log("Player has died");
        onPlayerDeath?.Invoke();
    }
    public static void RespawnPlayer()
    {
        //Debug.Log("Player has been respawned");
        onPlayerRespawn?.Invoke();
    }

    public static void TurretSpawned(string turretTag)
    {
        onTurretSpawn?.Invoke(turretTag);
    }
    public static void TurretDestroyed(string turretTag)
    {
        //Debug.Log("Turret Destroyed");
        onTurretDestruct?.Invoke(turretTag);
    }
    public static void AllTurretsDestroyed()
    {
        //Debug.Log("Next Objective completed");
        onAllTurretsDestroyed?.Invoke();
    }

    public static void EnemyCarrierDestroyed()
    {
        Debug.Log("Game Finished");
        onEnemyCarrierDestroyed?.Invoke();
    }
    public static void AllyCarrierDestroyed()
    {
        Debug.Log("Game Finished");
        onEnemyCarrierDestroyed?.Invoke();
    }
    public static void MatchFinished()
    {
        Debug.Log("Changing Scene");
        onMatchFinished?.Invoke();
    }

    public static void EnemyKilled()
    {
        Debug.Log("Enemy killed");
        onEnemyKilled?.Invoke();
    }
    public static void AllyKilled()
    {
        Debug.Log("Ally killed");
        onAllyKilled?.Invoke();
    }
}
