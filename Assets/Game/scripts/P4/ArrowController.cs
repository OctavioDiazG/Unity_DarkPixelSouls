using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    ///*
    public float speed;
    private float timed_Arrow_Life = 10.0f;
    private float Arrow_Start_Time = 0.0f;
    private Rigidbody2D arrowRB2D;
    public PlayerController player; //llamamos el script del jugador
    //public GameObject enemyDeathFX; //referencia de particulas de muerte
    public GameObject ImpactFX;
    public int damageToGive; //daño de proyectil
    //public int pointsForKill; //puntaje al matar al enemigo

    void Start() 
    {
        arrowRB2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        if(player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
    }
    private void OnEnable() 
    {
        Arrow_Start_Time = Time.time;
    }
    void Update()
    {
        arrowRB2D.velocity = new Vector2(speed, arrowRB2D.velocity.y);
        
        if(Time.time - Arrow_Start_Time > timed_Arrow_Life)
        {
            Destroy(gameObject);
        }
        if(player.direccion == false)
        {
            transform.localScale = new Vector3 (-0.75f, 0.75f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy_Health_Manager>().DamageEnemy(damageToGive);
            Destroy(gameObject);
            Instantiate(ImpactFX, arrowRB2D.transform.position, arrowRB2D.transform.rotation);
            //Destroy(other.gameObject);
            //Instantiate(enemyDeathFX, other.transform.position, other.transform.rotation);
            //Score_System.AddPoints(pointsForKill);
        }    
        else if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            Instantiate(ImpactFX, arrowRB2D.transform.position, arrowRB2D.transform.rotation);
        }
    }
    //*/
    /*
    [SerializeField]
    private float timed_Arrow_Life = 2.0f;
    private float Arrow_Start_Time = 0.0f;
    [SerializeField]
    private float ArrowSpeed = 40.5f;
    [SerializeField]
    private Rigidbody2D Arrow_PF; 

    void Start() 
    {
        Arrow_PF = this.GetComponent<Rigidbody2D>();
        Arrow_PF.velocity = new Vector2(-ArrowSpeed, 0);
    }
    private void OnEnable() 
    {
        Arrow_Start_Time = Time.time;
    }
    void Update()
    {
        if(Time.time - Arrow_Start_Time > timed_Arrow_Life)
        {
            Destroy(gameObject);
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }    
    }
    */
}
