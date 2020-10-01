using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// code relating to player
/// </summary>
public class Player : MonoBehaviour
{
    public PlayerStats playerStats;

    //public float testHealth = 100;

    private void Update()
    {
        //playerStats.CurrentHealth = testHealth;
    }

    private void OnGUI()
    {
        //DIsplay our current health
        //DIsplay our current mana
        //DIsplay our current stamina
    }

    public void DealDamage(float damage)
    {
        playerStats.CurrentHealth -= damage;
    }

    public void Heal(float health)
    {
        playerStats.CurrentHealth += health;
    }
}




/*
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
*/

