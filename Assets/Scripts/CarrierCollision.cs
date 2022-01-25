using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ally") || other.gameObject.CompareTag("Enemy"))
        {
            CarrierHealth tempCarrierHP = transform.root.GetComponent<CarrierHealth>();
            if (tempCarrierHP != null)
                tempCarrierHP.TakeDamage(10);
            else
                Debug.LogWarning("Carrier collision error, is carrier health script active?");
        }
    }
}
