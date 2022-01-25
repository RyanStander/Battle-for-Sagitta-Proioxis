using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int curHealth;
    
    private void Start()
    {
        curHealth = maxHealth;
        EventManager.TurretSpawned(gameObject.tag);
    }
    public void TakeDamage(int dmg = 1)
    {
        curHealth -= dmg;
        if (curHealth < 0)
            curHealth = 0;

        if (curHealth < 1)
        {
            EventManager.TurretDestroyed(gameObject.tag);
            Explosions temp = transform.GetComponent<Explosions>();
            temp.CollidedWithEnemy();
        }
    }
}
