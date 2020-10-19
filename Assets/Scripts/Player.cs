using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// code relating to player
/// </summary>
public class Player : MonoBehaviour
{


    public PlayerStats playerStats;
    private bool disableRegen = false;
    private float disableRegenTime;
    public float RegenCooldown = 5f;

    private PlayerProfession profession;

    public PlayerProfession Profession 
    { 
        get
        {
            return profession;
        }
        set
        {
            ChangeProfession(value);
        }
    }


    public void ChangeProfession(PlayerProfession cProfession)
    {
        profession = cProfession;
        SetUpProfession();
    }

    public void SetUpProfession()
    {
        for (int i = 0; i < playerStats.baseStats.Length; i++)
        {
            if (i < profession.defaultStats.Length)// check if i exist in profession
            {
                playerStats.baseStats[i].defaultStat = profession.defaultStats[i].defaultStat;
            }



        }
    }

    private void Update()
    {
        if (!disableRegen)
        {
            if (playerStats.CurrentHealth < playerStats.maxHealth)
            {
                playerStats.CurrentHealth += playerStats.regenHealth * Time.deltaTime;
            }
        }
        else
        {
            if(Time.time > disableRegenTime + RegenCooldown)
            {
                disableRegen = false;
            }
        }
        
    }

    public void LevelUp()
    {
        playerStats.baseStatePoints += 3;

        for(int i = 0; i < playerStats.baseStats.Length; i++)
        {
            playerStats.baseStats[i].additionalStat += 1;
        }
    }

    public void DealDamage(float damage)
    {
        playerStats.CurrentHealth -= damage;
        disableRegen = true;
        disableRegenTime = Time.time;
    }
    public void Heal(float health)
    {
        playerStats.CurrentHealth += health;
    }
    public void OnGUI()
    {
        if (GUI.Button(new Rect(130, 10, 100, 20), "Level Up"))
        {
            LevelUp();
        }

        if (GUI.Button(new Rect(130, 40, 120, 20), "Do Damage: " + playerStats.CurrentHealth))
        {
            DealDamage(25f);
        }
    }
}



