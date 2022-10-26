using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Manager : MonoBehaviour
{
    public int damage; //daño que hace el objeto al jugador
    public LVL_Manager lvlmanager; //referencia del script LVL_Manager
    public PlayerController player;

    void Start()
    {
        lvlmanager = FindObjectOfType<LVL_Manager>();
        player = FindObjectOfType<PlayerController>();
    }
    
    void OnTriggerEnter2D(Collider2D _other) //cuando entra en contacto con el objeto
    {
        if(_other.tag == "Player")
        {
            player.currentHealth = player.currentHealth -damage;
            PlayerController _Player = _other.GetComponent<PlayerController>();
            _Player.KnockBackCounter = _Player.KnockBackLength;
            if(_other.transform.position.x < transform.position.x)
            {
                _Player.KnockFromRight = true;
            }
            else
            {
                _Player.KnockFromRight = false;
            }
        }
        else
        {
            if(player.currentHealth <= 0)
            {
                lvlmanager.RespawnPlayer(); //llamamos la funcion de otro script
            }
        }
    }
}
