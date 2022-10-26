using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Patrol : MonoBehaviour
{
    [Header("Movimiento de Enemigo")]
    public float moveSpeed;
    public bool moveRight;
    [Header("Deteccion de paredes")]
    public Transform wallCheck; //punto para detectar paredes
    public float wallCheckRadius; //radio del circulo
    public LayerMask whatIsWall;
    [Header("Deteccion de orillas")]
    public Transform edgeCheck; //punto para detectar orillas
    public float edgeChechRadius;
    public LayerMask whatIsEdge;
    private Rigidbody2D enemyRB2D;
    private bool hittingWall;
    private bool notAtEdge;

    void Start()
    {
        enemyRB2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position,wallCheckRadius,whatIsWall);
        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, edgeChechRadius,whatIsEdge);
    }

    void Update()
    {
        if(hittingWall || !notAtEdge) 
        {
            moveRight = !moveRight;
        }
        if(moveRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            enemyRB2D.velocity = new Vector2(moveSpeed,enemyRB2D.velocity.y);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            enemyRB2D.velocity = new Vector2(-moveSpeed,enemyRB2D.velocity.y);
        }
    }
}

/*
public class Enemy_Patrol : MonoBehaviour
{
    public float moveSpeed; //velocidad del enemigo 
    public bool moveRight;
    public Transform wallCheck; //para detectar paredes
    public float wallCheckRadius; //radio del circulo para detectar paredes
    public LayerMask whatisWall; //layer de paredes

    private Rigidbody2D enemyRB2D; //referencia del RigidBody del enemigo
    private bool hittingWall; //saber si el enemigo esta tocando paredes

    void Start() 
    {
        enemyRB2D = GetComponent<Rigidbody2D>();
    }

    void FixedUPdate()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatisWall);
    }

    void Update() 
    {
        if(hittingWall)
        {
            moveRight = !moveRight; //si es true, lo vuleve falso y si es falso lo vuelve true.
        }
        if(moveRight)
        {
            enemyRB2D.velocity = new Vector2(moveSpeed, enemyRB2D.velocity.y); //mover a la derecha
        }
        else
        {
            enemyRB2D.velocity = new Vector2(-moveSpeed, enemyRB2D.velocity.y); //mover a la izquierda
        }
    }

}
*/