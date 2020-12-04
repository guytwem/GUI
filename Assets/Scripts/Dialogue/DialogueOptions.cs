using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptions : MonoBehaviour
{
    #region Variables
    [Header("References")]
    public bool showDialogue;
    public int currentLineIndex;

    public Text NPCattitude;

    public bool disliked = true;
    public bool neutral = false;
    public bool liked = false;

    public ThirdPersonMovement playerMovement;

    public Vector2 scr;

    [Header("Name and Dialogue")]
    public string name;
    public string[] dialogueText;
    #endregion

    private void Update()
    {
        if (disliked == true)
        {
            NPCattitude.text = "Disliked".ToString();
        }
        if (neutral == true)
        {
            NPCattitude.text = "Neutral".ToString();
        }
        if (liked == true)
        {
            NPCattitude.text = "Liked".ToString();
        }
    }

    private void OnGUI()
    {
        if (showDialogue)
        {
            playerMovement.enabled = false;
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;

            GUI.Box(new Rect(0, 6 * scr.y, Screen.width, scr.y * 3), name + " : " + dialogueText[currentLineIndex]);

            if (disliked == true)
            {
               


                if (currentLineIndex == 0 || currentLineIndex == 1)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Next"))
                    {
                        currentLineIndex++;
                    }

                }
                if (currentLineIndex == 2)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Andrew?"))
                    {
                        disliked = false;

                        neutral = true;

                        currentLineIndex = 3;

                    }
                    if (GUI.Button(new Rect(10 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Manny?"))
                    {
                        currentLineIndex = 6;
                    }
                    if (GUI.Button(new Rect(5 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "James?"))
                    {
                        currentLineIndex = 6;
                    }
                }
            }

            if(neutral == true)
            {
                
                GUI.Box(new Rect(0, 6 * scr.y, Screen.width, scr.y * 3), name + " : " + dialogueText[currentLineIndex]);
                if (currentLineIndex == 3)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Next"))
                    {
                        currentLineIndex++;
                    }


                }
                if (currentLineIndex == 4)
                {
                    if (GUI.Button(new Rect(10 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Good"))
                    {


                        neutral = false;

                        liked = true;

                        currentLineIndex = 5;

                    }
                    if (GUI.Button(new Rect(5 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Bad"))
                    {
                        currentLineIndex = 7;
                    }

                }
            }

            if (liked == true)
            {
                
                GUI.Box(new Rect(0, 6 * scr.y, Screen.width, scr.y * 3), name + " : " + dialogueText[currentLineIndex]);
                if (currentLineIndex == 5)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "I like you too!"))
                    {
                        showDialogue = false;
                        playerMovement.enabled = true;
                    }

                   


                }
            }


            else
            {
                if (currentLineIndex == 6 || currentLineIndex == 7 && GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Bye"))
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
}
