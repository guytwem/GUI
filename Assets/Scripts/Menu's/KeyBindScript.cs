using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyBindScript : MonoBehaviour
{

    private static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text up, down, left, right, jump;

    private GameObject currentKey;

    private void Start()
    {
        keys.Add("Up", KeyCode.W);
        keys.Add("Down", KeyCode.S);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);
        keys.Add("Jump", KeyCode.Space);

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        jump.text = keys["Jump"].ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyBindScript.keys["Up"]))
        {
            Debug.Log("Up");
        }
        if (Input.GetKeyDown(KeyBindScript.keys["Down"]))
        {
            Debug.Log("Down");
        }
        if (Input.GetKeyDown(KeyBindScript.keys["Left"]))
        {
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(KeyBindScript.keys["Right"]))
        {
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(KeyBindScript.keys["Jump"]))
        {
            Debug.Log("Jump");
        }
    }

    private void OnGUI()
    {

        string newKey = "";
        Event e = Event.current;

        if (currentKey != null)
        {

            if (e.isKey)
            {

                newKey = e.keyCode.ToString();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                newKey = "LeftShift";
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                newKey = "RightShift";
            }
            if (newKey != "")
            {//we change our dictionary
                keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);
                // change the text of our button
                currentKey.GetComponentInChildren<Text>().text = newKey;
                //currentKey.GetComponent<Image>().color = changedKey;
                currentKey = null;
            }
        }


    }

    public void ChangeKey(GameObject clickKey)
    {
        currentKey = clickKey;
        //ignore the next line
    }
}
