using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    #region Variables
    [Header("References")]
    public bool showDialogue;
    public int currentLineIndex;

    public ThirdPersonMovement playerMovement;

    public Vector2 scr;

    [Header("Name and Dialogue")]
    public string name;
    public string[] dialogueText;
    #endregion

    private void OnGUI()
    {
        if (showDialogue)
        {
            playerMovement.enabled = false;
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;

            GUI.Box(new Rect(0, 6 * scr.y, Screen.width, scr.y * 3), name + " : " + dialogueText[currentLineIndex]);

            if (currentLineIndex < dialogueText.Length - 1)
            {
                if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Next"))
                {
                    currentLineIndex++;
                }
            }
            else
            {
                if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Bye"))
                {
                    showDialogue = false;
                    currentLineIndex = 0;

                    playerMovement.enabled = true;
                    //Cursor.lockState = CursorLockMode.Locked;
                    //Cursor.visible = false;
                }
            }
        }
    }

    protected virtual void EndDialogue()
    {
        //if(GUI.Button(new Rect(15 * )))
    }
    
}
