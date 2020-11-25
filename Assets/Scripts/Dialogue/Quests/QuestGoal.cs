using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState {Available, Active, Claimed}

public enum GoalType { Gather /*kill, escort, locate*/}

[System.Serializable]
public abstract class QuestGoal : MonoBehaviour
{
    public QuestState questState;

    public GoalType goalType;

    

    

    public abstract bool isCompleted();

    
    /*public void ItemCollected(string name)
    {
        if(goalType == GoalType.Gather && itemName == name)
        {
            currentAmount++;
            if(currentAmount >= requiredAmount)
            {
                questState = QuestState.Completed;
                Debug.Log("Quest Completed");
            }
        }
    }*/
    
}
