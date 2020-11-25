using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : NPC
{

     protected QuestManager questManager;

    [SerializeField] protected Quest NPCsQuest;


    public void Start()
    {
        questManager = FindObjectOfType<QuestManager>();

        if(questManager == null)
        {
            Debug.LogError("There is no QuestManager in the scene");
        }
    }
    public override void Interact()
    {
        switch (NPCsQuest.goal.questState) 
        {
            case QuestState.Available:
                questManager.AcceptQuest(NPCsQuest);
                Debug.Log("Accepted");
                break;
            case QuestState.Active:
                if (NPCsQuest.goal.isCompleted())
                {
                    Debug.Log("Claimed");
                    questManager.ClaimQuest();
                }
                else
                {
                    Debug.Log("Not Claimed");
                }
                break;
            case QuestState.Claimed:
                //some dialog 
                //already completed quest
                break;
        }
        

        if(NPCsQuest.goal.questState == QuestState.Available)
        {
            questManager.AcceptQuest(NPCsQuest);
            
        }
        
    }
}
