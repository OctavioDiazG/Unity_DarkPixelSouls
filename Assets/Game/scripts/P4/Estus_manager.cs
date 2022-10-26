using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estus_manager : MonoBehaviour
{
    //public int Healthrecovery;
    //public LVL_Manager lvlmanager; //referencia del script LVL_Manager
    public PlayerController player;

    void Start()
    {
        //lvlmanager = FindObjectOfType<LVL_Manager>();
        player = FindObjectOfType<PlayerController>();
    }
    
    void OnTriggerEnter2D(Collider2D _other) //cuando entra en contacto con el objeto
    {
        if(_other.tag == "Player")
        {
            player.currentHealth = player.MaxHealth;
            //PlayerController _Player = _other.GetComponent<PlayerController>();
            Destroy(gameObject);
        }
    }
}
