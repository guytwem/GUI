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

[System.Serializable]
public class Stats 
{
    [Header("Player Movement")]
    public float speed = 6F;
    public float sprintSpeed = 12f;
    public float crouchSpeed = 3f;
    public float jumpHeight = 1.0f;
    

    [Header("Current Stats")]
    public int level;
    public float maxHealth = 100;
    public float regenHealth = 5f;
    public float maxMana = 100;
    public float currentMana = 100;

    public float currentStamina = 100;
    public float regenStamina = 5f;
    public float maxStamina = 100;


    [Header("Base Stats")]
    public int baseStatePoints = 10;
    public BaseStats[] baseStats;

}


/// <summary>
/// stores the players stats
/// </summary>
[System.Serializable]
public class PlayerStats
{

    public Stats stats;

   


    private float _currentHealth = 100;
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, stats.maxHealth);
            
            if (healthHearts != null)
            {
                healthHearts.UpdatedHearts(value, stats.maxHealth);
            }
        }
    }
    public QuarterHearts healthHearts;

    public bool SetStats(int statIndex, int amount)
    {
        //increasing
        if (amount > 0 && stats.baseStatePoints - amount < 0)
        {
            return false;
        }
        else if (amount < 0 && stats.baseStats[statIndex].additionalStat + amount < 0) // decreasing
        {
            return false;
        }

        stats.baseStats[statIndex].additionalStat += amount;
        stats.baseStatePoints -= amount;


        return true;
    }
}
