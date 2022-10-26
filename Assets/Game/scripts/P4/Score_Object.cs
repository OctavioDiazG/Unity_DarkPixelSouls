using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Object : MonoBehaviour
{
    public int pointsToAdd;

    void OnTriggerEnter2D(Collider2D _other) 
    {
        if(_other.GetComponent<PlayerController>() == null)
        {
            return;    
        }
        Score_System.AddPoints(pointsToAdd); //agrega los puntos al jugador
        Destroy(gameObject); //destruye el objeto que contiene los puntos
    }
}
