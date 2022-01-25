using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ally") || other.gameObject.CompareTag("Enemy"))
        {
            PlayerHealth tempPlayerHP = transform.root.GetComponent<PlayerHealth>();
            if (tempPlayerHP != null)
                tempPlayerHP.TakeDamage(tempPlayerHP.GetMaxHP());
            else
                Debug.LogWarning("Player collision error, is player health script active?");

        }
    }
}
