using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timed_Fireball : MonoBehaviour
{
    [SerializeField]
    private float timed_Fireball_Life = 2.0f;
    private float Fireball_Start_Time = 0.0f;
    [SerializeField]
    private float FireballSpeed = 40.5f;
    [SerializeField]
    private Rigidbody2D Fireball_PF; 

    void Start() 
    {
        Fireball_PF = this.GetComponent<Rigidbody2D>();
        Fireball_PF.velocity = new Vector2(-FireballSpeed, 0);
    }
    private void OnEnable() 
    {
        Fireball_Start_Time = Time.time;
    }
    void Update()
    {
        if(Time.time - Fireball_Start_Time > timed_Fireball_Life)
        {
            Destroy(gameObject);
        }    
    }
}
