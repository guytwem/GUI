using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Player player;
    public Inventory inventory;

    Dialogue dialogue;

    //QuestGiver
    private Quest currentQuest;

    


    public void AcceptQuest(Quest acceptedQuest)
    {
        currentQuest = acceptedQuest;
        currentQuest.goal.questState = QuestState.Active;
    }

    

    public void ClaimQuest()
    {
        if (currentQuest.goal.questState == QuestState.Active && currentQuest.goal.isCompleted() == true)
        {
            inventory.money += currentQuest.goldReward;
            
            //add xp

            currentQuest.goal.questState = QuestState.Claimed;
            Debug.Log("Quest Claimed");
        }
    }
}
