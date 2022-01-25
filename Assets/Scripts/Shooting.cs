using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] bool isPlayerBullet = false;

    private Rigidbody rb;

    [SerializeField] float lifeSpan = 10;
    void Start()
    {
        lifeSpan += Time.time;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //rb.AddForce(transform.forward * bulletSpeed* Time.deltaTime);
        rb.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        if (Time.time>lifeSpan)
        {
            Destroy(transform.root.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ally")|| other.gameObject.CompareTag("Enemy"))
        {
            //check for any of the components existing on the other object, if it finds any it will perform different functions
            //for each
            Explosions temp = other.transform.root.GetComponent<Explosions>();
            if (temp != null)
                temp.GotShot(transform.position);

            AIHealth tempAI= other.transform.root.GetComponent<AIHealth>();
            if (tempAI != null)
                tempAI.TakeDamage(isPlayerBullet);

            PlayerHealth tempPlayerHP = other.transform.GetComponent<PlayerHealth>();
            if (tempPlayerHP != null)
                tempPlayerHP.TakeDamage();

            TurretHealth tempTurretHP = other.transform.GetComponent<TurretHealth>();
            if (tempTurretHP != null)
                tempTurretHP.TakeDamage();

            CarrierHealth tempCarrierHP = other.transform.root.GetComponent<CarrierHealth>();
            if (tempCarrierHP != null)
                tempCarrierHP.TakeDamage();


            Destroy(transform.root.gameObject);
        }
    }
    public float GetLifeSpan()
    {
        return lifeSpan;
    }
}
