using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] float turnSpeed = 10;

    [SerializeField] Transform turretHead;
    [SerializeField] Transform turretBody;

    private GameObject[] players;
    [SerializeField] string Target;

    [SerializeField] GameObject bullet;
    [SerializeField] float FireRate = 0.5f;
    private float NextFire;
    private AudioSource audioSource;

    private bool targetSpotted = false;
    private Vector3 rayDirection;

    void Start()
    {
        if (turretHead == null)
        {
            turretHead = transform.Find("Turret_Head");
        }
        audioSource = transform.GetComponent<AudioSource>();

    }
    void Update()
    {
        Raycasting();
        Fire();
    }

    public void Raycasting()
    {
        //check which target is the closest
        players = GameObject.FindGameObjectsWithTag(Target);
        GameObject closest = players[0];
        rayDirection = players[0].transform.position - transform.position;
        foreach (GameObject player in players)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < Vector3.Distance(transform.position, closest.transform.position))
            {
                rayDirection = player.transform.position - transform.position;
                closest = player;

            }
        }
        RaycastHit hit;
        //depending on which is closes it will start rotating towards it
        if (Physics.Raycast(transform.position, rayDirection, out hit))
        {
            if (hit.collider.gameObject.tag == Target)
            {
                //Debug.DrawRay(transform.position, rayDirection, Color.green);
                rotateTowards(closest);
                targetSpotted = true;
            }
            else
            {
                //Debug.DrawRay(transform.position, rayDirection, Color.red);
                targetSpotted = false;
            }
        }
    }

    public void Fire()
    {
        //if the turret can see a target without obstruction it will start shooting
        if (targetSpotted && Time.time > NextFire)
        {
            if (audioSource != null)
                audioSource.Play();
            else
                Debug.Log("cant find audiosource");
            Transform temp = turretHead.transform.Find("SpawnPoint");
            //GameObject bulletClone = Instantiate(bullet, turretHead.transform.position, turretHead.transform.rotation);
            NextFire = Time.time + FireRate;
            GameObject bulletClone = Instantiate(bullet, temp.position, temp.rotation);
        }
    }

    protected void rotateTowards(GameObject to)
    {
        //This function makes it so that the turret will rotate towards the designated target and start shooting
        //if there is no body it will designate all movement to the head of the turret
        if (turretBody != null)
        {
            //----------------------------
            //    Turret Body Movement
            //----------------------------
            Vector3 lookPos = to.transform.position - turretBody.transform.position;
            Quaternion turretBodyTargetRotation = Quaternion.LookRotation(lookPos);

            turretBodyTargetRotation *= Quaternion.Euler(270, 0, 90);
            turretBody.transform.rotation = Quaternion.Slerp(turretBody.transform.rotation, turretBodyTargetRotation, Time.deltaTime * turnSpeed);
            turretBody.transform.eulerAngles = new Vector3(270, turretBody.transform.eulerAngles.y, turretBody.transform.eulerAngles.z);

            //----------------------------
            //    Turret Head Movement
            //----------------------------
            Vector3 lookDirection = to.transform.position - turretHead.transform.position;
            Quaternion turretTargetRotation = Quaternion.LookRotation(lookDirection);

            turretTargetRotation *= Quaternion.Euler(270, 0, 90);
            turretHead.transform.rotation = Quaternion.Slerp(turretHead.transform.rotation, turretTargetRotation, Time.deltaTime * turnSpeed);
        }
        else
        {
            //----------------------------
            // Turret Head Movement Only
            //----------------------------
            Vector3 lookDirection = to.transform.position - turretHead.transform.position;
            Quaternion turretTargetRotation = Quaternion.LookRotation(lookDirection);

            turretTargetRotation *= Quaternion.Euler(0, 270, -10);
            turretHead.transform.rotation = Quaternion.Slerp(turretHead.transform.rotation, turretTargetRotation, Time.deltaTime * turnSpeed);
        }
    }
}
