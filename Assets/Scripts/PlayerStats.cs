using UnityEngine;

[System.Serializable]
public struct BaseStats
{
    public string baseStatName;
    public int defaultStat;
    public int levelUpStat;
    public int additionalStat;

    public int finalStat 
    { 
        get 
        {
            return defaultStat + additionalStat + levelUpStat;
        }
    }
    
}

/// <summary>
/// stores the players stats
/// </summary>
[System.Serializable]
public class PlayerStats
{
    

    


    [Header("Player Movement")]
    public float speed = 6F;
    public float sprintSpeed = 12f;
    public float crouchSpeed = 3f;
    public float jumpHeight = 1.0f;
    public float gravity = -9.81f;

    [Header("Current Stats")]
     public int level;
     public float maxHealth = 100;
     public float regenHealth = 5f;
     public float maxMana = 100;
     public float currentMana = 100;
     public float currentStamina = 100;
     public float maxStamina = 100;
     

    [Header("Base Stats")]
    public int baseStatePoints = 10;
    public BaseStats[] baseStats;

    private float _currentHealth = 100;
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, maxHealth);
            
            if (healthHearts != null)
            {
                healthHearts.UpdatedHearts(value, maxHealth);
            }
        }
    }
    public QuarterHearts healthHearts;

    public bool SetStats(int statIndex, int amount)
    {
        //increasing
        if (amount > 0 && baseStatePoints - amount < 0)
        {
            return false;
        }
        else if (amount < 0 && baseStats[statIndex].additionalStat + amount < 0) // decreasing
        {
            return false;
        }

        baseStats[statIndex].additionalStat += amount;
        baseStatePoints -= amount;


        return true;
    }
}
