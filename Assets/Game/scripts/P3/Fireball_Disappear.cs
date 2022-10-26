using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Disappear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }    
    }
}
