using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_Data
{
    public int level;
    public float[] position;

    public Player_Data (PlayerController player)
    {
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
