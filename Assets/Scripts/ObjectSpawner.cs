using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeReference] GameObject[] objsToSpawn;
    [SerializeReference] int nextSpawnDelay = 1;
    private float _currentDelay;
    [SerializeReference] bool isRandomDelayToRange=false;
    [SerializeReference] int randomDelayMinVal = 1;
    // Start is called before the first frame update
    void Start()
    {
        _currentDelay = nextSpawnDelay+Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        StartSpawn();
    }
    private void SpawnObj()
    {
        GameObject spawnedObj = Instantiate(objsToSpawn[Random.Range(0, objsToSpawn.Length)], transform.position,transform.rotation);
    }
    private void StartSpawn()
    {
        if (isRandomDelayToRange)
        {
            if (Time.time > _currentDelay)
            {
                _currentDelay += Random.Range(randomDelayMinVal, nextSpawnDelay);
                SpawnObj();
            }
        }
        else
        {
            if (Time.time > _currentDelay)
            {
                _currentDelay += nextSpawnDelay;
                SpawnObj();
            }
        }
    }
    private void OnEnable()
    {
        EventManager.onStartGame += StartSpawn;
    }
    private void OnDisable()
    {
        EventManager.onStartGame -= StartSpawn;
    }
}
