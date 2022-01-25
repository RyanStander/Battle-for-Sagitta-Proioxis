using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosions : MonoBehaviour
{

    [SerializeField] float animationDurationBullet;
    [SerializeField] GameObject bulletExplosion;

    [SerializeField] float animationDurationExplosion;
    [SerializeField] GameObject shipExplosion;
    
    public void GotShot(Vector3 Pos)
    {
        GameObject boom = Instantiate(bulletExplosion, Pos, Quaternion.identity, transform) as GameObject;
        Destroy(boom, 2f);
    }
    public void CollidedWithEnemy()
    {
        //Debug.Log("Big stupid crashed!");
        GameObject boom = Instantiate(shipExplosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(boom, 4f);
        Destroy(gameObject);
    }
}
