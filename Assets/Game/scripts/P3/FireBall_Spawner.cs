using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Spawner : MonoBehaviour
{
    [SerializeField]
    private float FireBall_PerSec  = 1;
    private int FireBall_Counter = 0;
    [SerializeField]
    private FireBall_Factory FireBall_Factory;
    private Rigidbody2D FireBall;
    void Start() 
    {
        FireBall = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        var targetCount = Time.time * (FireBall_PerSec/1);
        while (targetCount > FireBall_Counter /*&& Input.GetKey(KeyCode.RightShift)*/)
        {
            var inst2 = FireBall_Factory.GetNewInstance2();
            inst2.transform.position = new Vector2(FireBall.position.x, FireBall.position.y);
            FireBall_Counter ++;
        }
    }
}
