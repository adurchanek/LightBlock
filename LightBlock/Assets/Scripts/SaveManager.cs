using System.Collections;
using System.IO;
using UnityEngine;
//using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void SavePlayer(Player p)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data  = new PlayerData(p);
        formatter.Serialize(stream, data);
        
        stream.Close();
    }
    
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.txt";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}