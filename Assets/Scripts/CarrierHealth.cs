using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 500;
    [SerializeField] int curHealth;

    private void Start()
    {
        curHealth = maxHealth;
    }
    public void TakeDamage(int dmg = 1)
    {
        curHealth -= dmg;
        if (curHealth < 0)
            curHealth = 0;

        if (curHealth < 1)
        {
            if (gameObject.tag == "Enemy")
            {
                EventManager.EnemyCarrierDestroyed();
                EventManager.MatchFinished();
                StaticValues.didWin = true;
            }
            else if (gameObject.tag == "Ally")
            {
                EventManager.AllyCarrierDestroyed();
                EventManager.MatchFinished();
                StaticValues.didWin = false;
            }
            Explosions temp = transform.GetComponent<Explosions>();
            temp.CollidedWithEnemy();
        }
    }
}
