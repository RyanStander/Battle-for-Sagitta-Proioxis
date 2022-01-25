using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : MonoBehaviour
{
    private Transform target;
    [SerializeField] string targetTag;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float targetDistance;
    [SerializeField] GameObject lazer;
    [SerializeField] AIMovement aiFighter;
    private float NextFire;
    [SerializeField] float FireRate = 10;
    private AudioSource[] audioSources;
    void Start()
    {
        if (targetTag == null)
            Debug.LogError("TargetTag was not set for " + gameObject.name + " AI will not function normally");
        audioSources = transform.root.GetComponents<AudioSource>();
    }
    void LateUpdate()
    {
        //takes current target and shoots at them if they are within certain constraints (refer to InFront())
        target = aiFighter.GetTarget();
        if (InFront()&& HaveLineOfSight())
        if (Time.time > NextFire)
        {
                audioSources[0].Play();
                NextFire = Time.time + FireRate;

            foreach (Transform spawnPoint in spawnPoints)
            {
                GameObject bulletClone = Instantiate(lazer, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
    public bool InFront()
    {
        if (target == null)
        {
            return false;
        }
        else
        {
            Vector3 directionToTarget = transform.position - target.position;
            float angle = Vector3.Angle(transform.forward, directionToTarget);

            //Check if it is in range
            if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
            {
                //Debug.DrawLine(transform.position, target.position, Color.green);
                return true;
            }
            //Debug.DrawLine(transform.position, target.position, Color.red);
            return false;
        }
    }

    public bool HaveLineOfSight()
    {
        RaycastHit hit;


        foreach (Transform spawnPoint in spawnPoints)
        {
            Vector3 direction = target.position - spawnPoint.position;

            if (Physics.Raycast(spawnPoint.position, direction, out hit, targetDistance))
            {
                Debug.DrawRay(spawnPoint.position, direction, Color.green);
                    if (hit.collider.gameObject.tag == targetTag)
                    {
                        return true;
                    }
            }


        }
        return false;
    }
}
