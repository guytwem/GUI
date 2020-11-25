using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] private Image staminaBar;

    [SerializeField] private Player player;

   


    public void StaminaChange()
    {
        float amount = Mathf.Clamp01(player.playerStats.stats.currentStamina / player.playerStats.stats.maxStamina);

        staminaBar.fillAmount = amount;
    }

}
