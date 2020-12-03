using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : NPC
{

     protected QuestManager questManager;

    [SerializeField] protected Quest NPCsQuest;

    [SerializeField] private Dialogue dialogue;

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
        if(NPCsQuest.goal.questState == QuestState.Available)
        {
            dialogue.showDialogue = true;
            dialogue.currentLineIndex = 0;
            if(dialogue.currentLineIndex == 2)
            {
                dialogue.showDialogue = false;
            }
        }
        if (NPCsQuest.goal.questState == QuestState.Claimed)
        {
            dialogue.showDialogue = true;
            dialogue.currentLineIndex = 2;
            
        }

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
                dialogue.currentLineIndex = 2;
                break;
        }


        if (NPCsQuest.goal.questState == QuestState.Available)
        {
            questManager.AcceptQuest(NPCsQuest);

        }

    }
    private void OnGUI()
    {
        if (NPCsQuest.goal.questState == QuestState.Active)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Quest Accepted: Needy Pete Needs 5 Potions");
        }
        if (NPCsQuest.goal.questState == QuestState.Claimed)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Quest Completed: Congrats");
        }
    }
}
