using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : NPC
{
    [SerializeField] private DialogueOptions dialogue;

    
    //[SerializeField] public protected string[] text;

    public override void Interact()
    {
        dialogue.showDialogue = true;
        Debug.Log("Dialogue NPC");
    }
}
