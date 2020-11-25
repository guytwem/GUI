using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
/// <summary>
/// code relating to player
/// </summary>

[System.Serializable]
public class Player : MonoBehaviour
{


    public PlayerStats playerStats;
    private bool disableRegen = false;
    private float disableRegenTime;
    public float RegenCooldown = 5f;

    //private bool disableStaminaRegen = false;
    public float disableStaminaRegenTime;
    public float StaminaRegenCooldown = 1f;
    public float StaminaDegen = 30f;
      

    public int[] customisationTextureIndex;

    [SerializeField]
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

    private void Awake()
    {
        //Load player data
        if(SceneManager.GetActiveScene().name != "Customise")
        {
            PlayerData loadedPlayer = PlayerBinarySave.LoadPlayerData();
            if (loadedPlayer != null)
            {
                playerStats.stats = loadedPlayer.stats;
                profession = loadedPlayer.profession;
                customisationTextureIndex = loadedPlayer.customisationTextureIndex;
            }
        }
        
        
    }

    public void ChangeProfession(PlayerProfession cProfession)
    {
        profession = cProfession;
        SetUpProfession();
    }

    public void SetUpProfession()
    {
        for (int i = 0; i < playerStats.stats.baseStats.Length; i++)
        {
            if (i < profession.defaultStats.Length)// check if i exist in profession
            {
                playerStats.stats.baseStats[i].defaultStat = profession.defaultStats[i].defaultStat;
            }



        }
    }

    private void Update()
    {
        Interact();

        #region health regen
        if (!disableRegen)
        {
            if (playerStats.CurrentHealth < playerStats.stats.maxHealth)
            {
                playerStats.CurrentHealth += playerStats.stats.regenHealth * Time.deltaTime;
            }
        }
        else
        {
            if (Time.time > disableRegenTime + RegenCooldown)
            {
                disableRegen = false;
            }
        }
        #endregion

        #region stamina regen
        if (Time.time > disableStaminaRegenTime + StaminaRegenCooldown)
        {
            if (playerStats.stats.currentStamina < playerStats.stats.maxStamina)
            {
                playerStats.stats.currentStamina += playerStats.stats.regenStamina * Time.deltaTime;
            }
            else
            {
                playerStats.stats.currentStamina = playerStats.stats.maxStamina;
            }
        }
       
        #endregion
    }

    public void LevelUp()
    {
        playerStats.stats.baseStatePoints += 3;

        for(int i = 0; i < playerStats.stats.baseStats.Length; i++)
        {
            playerStats.stats.baseStats[i].additionalStat += 1;
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

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))//keybinding code here
        {
            Ray ray;
            RaycastHit hitInfo;

            ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            //how you make a mask
            int layerMask = LayerMask.NameToLayer("Interactable"); // get layer ID

            layerMask = 1 << layerMask; // actually turning it into a mask (using bitwise operations)

            int itemLayerMask = LayerMask.NameToLayer("items");
            itemLayerMask = 1 << itemLayerMask;

            int finalLayerMask = layerMask | itemLayerMask;


            if (Physics.Raycast(ray, out hitInfo, 10f, finalLayerMask))
            {

                if (hitInfo.collider.TryGetComponent<NPC>(out NPC npc))
                {
                    npc.Interact();
                }

                /*if(hitInfo.collider.TryGetComponent<InWorldItem>(out InWorldItem item))
                {
                    item.FoundItem();
                }
                */
                //items
            }

            
        }
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



