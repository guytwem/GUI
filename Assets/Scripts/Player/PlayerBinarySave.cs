
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class PlayerBinarySave : MonoBehaviour
{
    public static void SavePlayerData(Player player)
    {
        //reference to binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //location to save
        string path = Application.dataPath + "/playerSave.sav";
        //Create file at file path
        FileStream stream = new FileStream(path, FileMode.Create);

        //converts to a class we can actually save
        PlayerData data = new PlayerData(player);

        //Serialise player and save it to file
        formatter.Serialize(stream, data);
        //close the file
        stream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        //location to load from
        string path = Application.dataPath + "/playersave.sav";
        //if we have a file at that path
        if (File.Exists(path))
        {
            //get binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //read the data from the path
            FileStream stream = new FileStream(path, FileMode.Open);
            //Deserialize back to a usable variable
            PlayerData data = (PlayerData)formatter.Deserialize(stream);// as player



            //close the file
            stream.Close();

            return data;
        }

        return null;
    }
}
