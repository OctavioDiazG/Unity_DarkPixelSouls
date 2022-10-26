using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public
    //variables del jugador
    public float moveSpeed;
    private float moveVelocity; //saves the Velocity of the player
    public float jumpPower;
    public bool direccion = true; //derecha pendido izquierda apagado
    [Header("Deteccion de tierra")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    [Header("Proyectiles")]
    public Transform firePoint; //punto que origina los poryectiles
    public GameObject Arrow; //reference del proyectil
    public float shotDelay; //cadencia de fuego en el disparo
    [Header("Vida")]           
    public int MaxHealth = 10;   
    public int currentHealth;   
    public HealthBar HB;
    [Header("KnockBack")]
    public float KnockBackDistance;
    public float KnockBackLength;
    public float KnockBackCounter;
    public bool KnockFromRight;
    [Header("otros")]
    [SerializeField]
    private Rigidbody2D RB2D2;
    private bool doubleJump;
    private Animator Anim;
    private float shotDeayCounter; //contador de catencia de fuego del disparo

    void Start()
    {
        currentHealth = MaxHealth;  //****
        HB.SetMaxHealth(MaxHealth);
        RB2D2 = GetComponent<Rigidbody2D>();//el rigidbody que se le pone al script

        Anim = GetComponent<Animator>(); //referencia al Animator
    }

    void FixedUpdate()
    {             //crea un circulo      posicion de circle     tamaño de circle      si es que toca este layer = true
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void Update()
    {
        Movement();
        Health_Bar_admin();
    }

    void Movement()
    {
        if(grounded)//cuando en el piso double jump es falso
        {
            doubleJump = false;
        }
        //cuando toca el piso y presione espacio puede saltar
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            RB2D2.velocity = new Vector2(RB2D2.velocity.x, jumpPower);
        }
        //si double es falso y no esta en el piso puede saltar
        if (Input.GetKeyDown(KeyCode.Space) && !grounded && !doubleJump)
        {
            RB2D2.velocity = new Vector2(RB2D2.velocity.x, jumpPower);
            doubleJump = true;//no deja que se pueda saltar otra vez
        }
        //animacion de salto
        Anim.SetBool("Grounded", grounded);

        moveVelocity = 0f;
        //movimiento a la derecha
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //RB2D2.velocity = new Vector2(moveSpeed, RB2D2.velocity.y);
            moveVelocity = moveSpeed;
        }
        //movimiento a la izquierda
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //RB2D2.velocity = new Vector2(-moveSpeed, RB2D2.velocity.y);
            moveVelocity = -moveSpeed;
        }

        //RB2D2.velocity = new Vector2(moveVelocity, RB2D2.velocity.y);
        //knockBack
        if(KnockBackCounter <= 0)
        {
            RB2D2.velocity = new Vector2(moveVelocity,RB2D2.velocity.y);
        }
        else
        {
            if(KnockFromRight)
            {
                RB2D2.velocity = new Vector2(-KnockBackDistance,KnockBackDistance);
            }
            if(!KnockFromRight)
            {
                RB2D2.velocity = new Vector2(KnockBackDistance,KnockBackDistance);
            }
            KnockBackCounter -= Time.deltaTime;
        }
        
        //animacion de movimineto
        Anim.SetFloat("Speed", Mathf.Abs(RB2D2.velocity.x));

        //voltear al jugador
        if(RB2D2.velocity.x > 0f)
        {
            transform.localScale = new Vector3 (1f, 1f, 1f);
            direccion = true;
        }
        else if(RB2D2.velocity.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            direccion = false;
        }

        //disparo de proyectiles
        if(Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log ("mause presed");
            Instantiate(Arrow, firePoint.position, firePoint.rotation);
            shotDeayCounter = shotDelay;
        }
        if (Input.GetKey(KeyCode.S))
        {
            shotDeayCounter -= Time.deltaTime;
            if(shotDeayCounter <= 0) //para saber si ya podemos disparar el proyectil
            {
                shotDeayCounter = shotDelay;
                Instantiate(Arrow, firePoint.position, firePoint.rotation);
            }
        }
    }
    
    void Health_Bar_admin()
    {
        HB.SetHealth(currentHealth);
    }


    //Saving system
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer ()
    {
        Player_Data data = SaveSystem.LoadPlayer();
        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
    }
}

