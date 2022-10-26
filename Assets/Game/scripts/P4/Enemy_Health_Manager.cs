using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health_Manager : MonoBehaviour
{
    public int enemyHealth; //cantidad de vida del enemigo
    public GameObject enemyDeathFx;
    public int pointsForKill;

    void Update() 
    {
        if (enemyHealth <= 0)    
        {
            Instantiate(enemyDeathFx, transform.position, transform.rotation);

            Score_System.AddPoints(pointsForKill);

            Destroy(gameObject);
        }
    }

    //funcion para dañar al enemigo
    public void DamageEnemy(int _damageToGive)
    {
        enemyHealth -= _damageToGive;
    }
}
