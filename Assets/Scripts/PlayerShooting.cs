using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private float NextFire;
    public float FireRate = 10;
    public GameObject bullet;
    public Transform[] Guns;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            //plays sound and creates bullet to be fired
            if (Time.time > NextFire)
            {
                FindObjectOfType<AudioManager>().Play("AllyBullet");
                //GameObject bulletClone = Instantiate(bullet, turretHead.transform.position, turretHead.transform.rotation);
                NextFire = Time.time + FireRate;
                foreach (Transform gun in Guns)
                {
                    GameObject bulletClone = Instantiate(bullet, gun.position, gun.rotation);
                }
            }
        }
    }
}
