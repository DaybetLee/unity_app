﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    public static void SavePlayer(GameController player)
    {
        // Create new binary formatter
        BinaryFormatter formatter = new BinaryFormatter();

        // Save file path + file name
        string path = Application.persistentDataPath + "/player.detail";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.detail";
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

    public static void ClearData()
    {
        string path = Application.persistentDataPath + "/player.detail";
        if (File.Exists(path))
        {
            File.Delete(Application.persistentDataPath + "/player.detail");
        }
    }
}

