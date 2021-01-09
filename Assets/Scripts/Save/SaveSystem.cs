﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    
    public static void Save()
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "player.balloon";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData();

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "player.balloon";

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
            
            return null;
        }

    }

}
