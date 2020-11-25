using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GatherQuestGoals : QuestGoal
{
    private Inventory playerInventory;

    #region Gather Variables
    public string itemName;
    public int requiredAmount;

    #endregion
    private void Start()
    {
        playerInventory = (Inventory)GameObject.FindObjectOfType<Inventory>();
        if (playerInventory == null)
        {

            Debug.LogError("There is no player with an inventory in the scene");
           
        }
    }

  

    public override bool isCompleted()
    {
        
        Item item = playerInventory.FindItem(itemName);

        if(item == null)
        {
            return false;
        }

        if (item.Amount >= requiredAmount)
        {
            return true;
        }
        return false;
    }
}
