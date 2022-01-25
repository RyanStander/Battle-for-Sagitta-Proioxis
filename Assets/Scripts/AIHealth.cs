using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    private int curHealth;

    private void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(bool isPlayerBullet=false,int i = 1)
    {
        curHealth -= i;

        if (curHealth <= 0)
        {
            if (isPlayerBullet)
            {
                if (gameObject.tag == "Ally")
                    EventManager.AllyKilled();
                if (gameObject.tag == "Enemy")
                    EventManager.EnemyKilled();
            }
            Explosions temp = transform.root.GetComponent<Explosions>();
            temp.CollidedWithEnemy();
        }
       
    }
}
