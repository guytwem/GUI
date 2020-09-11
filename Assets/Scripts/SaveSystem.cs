using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //creates the file name and path only
        string path = Application.dataPath + "/player.meme";
        // opens the file
        FileStream stream = new FileStream(path, FileMode.Create);
        // creates the data to be saved
        PlayerData data = new PlayerData(player);
        //writes the data to the file and converts it to text
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.dataPath + "/Player.meme";

        if (File.Exists(path))
        {
            // load data
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not foind in " + path);
            return null;
        }
        
    }
}
