using UnityEngine;

/// <summary>
/// stores the players stats
/// </summary>
[System.Serializable]
public class PlayerStats
{
    [Header("Player Movement")]
    [SerializeField] public float speed = 6F;
    [SerializeField] public float sprintSpeed = 12f;
    [SerializeField] public float crouchSpeed = 3f;
    [SerializeField] public float jumpHeight = 1.0f;
    [SerializeField] public float gravity = -9.81f;

    [Header("Current Stats")]
    [SerializeField] public int level;
    [SerializeField] public float maxHealth = 100;
    [SerializeField] public float maxMana = 100;
    [SerializeField] public float currentMana = 100;
    [SerializeField] public float currentStamina = 100;
    [SerializeField] public float maxStamina = 100;
    [SerializeField] private float _currentHealth = 100;

    public GameObject deathScreen;
    
    
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            if (healthHearts != null)
            {
                healthHearts.UpdatedHearts(value, maxHealth);
            }
        }
    }
    public QuarterHearts healthHearts;

    public void Update()
    {
        if (_currentHealth <= 0f)
        {
            Debug.Log("Player Has Died!");
            deathScreen.SetActive(true);
        }
    }
}
