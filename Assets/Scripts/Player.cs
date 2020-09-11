using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 3;
    public int health = 55;


    public void Save()
    {
        SaveSystem.SavePlayer(this);//function that calls from SaveSystem script
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer(); // loads player data

        level = data.level;
        health = data.health;
        Vector3 pos = new Vector3(data.position[0],
                                    data.position[1],
                                    data.position[2]);

        transform.position = pos;
    }

}
