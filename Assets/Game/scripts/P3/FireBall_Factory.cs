using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Factory : MonoBehaviour
{
    [SerializeField]    
    private MonoBehaviour prefab2;
    
    public MonoBehaviour GetNewInstance2()
    {
        return Instantiate(prefab2);
    }
}
