using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public LVL_Manager levelmanager;
    // Start is called before the first frame update
    void Start()
    {
        levelmanager = FindObjectOfType<LVL_Manager>();
    }

    void OnTriggerEnter2D(Collider2D _other) 
    {
        if(_other.tag == "Player")
        {
            levelmanager.fcheckpoint = gameObject; //llamamos la funcion de otro script

            print ("checkpoint Activated: " + transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
