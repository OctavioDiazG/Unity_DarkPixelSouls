using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Manager : MonoBehaviour
{
    public GameObject fcheckpoint;
    public GameObject DeathParticle; //referencia las particulas de muerte
    public GameObject RespawnParticle; //referencia las particlas de reaparecimineto
    public float respawnTimer = 1f; //tiempo en el que se tarde en aparecer de nuevo 
    public int pointsDeathPenalty;

    private PlayerController player;//referencia al script del jugador
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCoRout");
    }

    public IEnumerator RespawnPlayerCoRout()
    {
        Instantiate(DeathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;  
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Score_System.AddPoints(-pointsDeathPenalty);
        player.currentHealth = player.MaxHealth;
        player.KnockBackCounter = 0;
        player.transform.position = fcheckpoint.transform.position;
        yield return new WaitForSeconds(respawnTimer); //pausar para continuar
        print ("player has respawned");
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        Instantiate(RespawnParticle, player.transform.position, player.transform.rotation);   
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Manager : MonoBehaviour
{
    public GameObject fcheckpoint;
    public GameObject DeathParticle; //referencia las particulas de muerte
    public GameObject RespawnParticle; //referencia las particlas de reaparecimineto
    public float respawnTimer = 1f; //tiempo en el que se tarde en aparecer de nuevo 
    public int pointsDeathPenalty;

    private PlayerController player;//referencia al script del jugador
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCoRout");
    }

    public IEnumerator RespawnPlayerCoRout()
    {
        Instantiate(DeathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;  
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Score_System.AddPoints(-pointsDeathPenalty);
        yield return new WaitForSeconds(respawnTimer); //pausar para continuar
        print ("player has respawned");
        player.transform.position = fcheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        Instantiate(RespawnParticle, player.transform.position, player.transform.rotation);   
    }
}

*/