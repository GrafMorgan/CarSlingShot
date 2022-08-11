using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataSaver
{

    static List<Profile> profiles = new List<Profile>();

    static DataSaver()
    {
        LoadData();
    }

    public static void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/CssSavedData.dat");
        SaveData data = new SaveData();
        data.profiles = profiles;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public static void LoadData()
    {

        if (File.Exists(Application.persistentDataPath + "/CssSavedData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/CssSavedData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            profiles = data.profiles;
            Debug.Log("Game data loaded!");
        }
        else
        {
            TableConfigurate();
            SaveData();
        }

    }

    public static void TableConfigurate() // метод временный, чисто чтобы создать хоть какую то таблицу
    {
        profiles.Add(new Profile("a", 23.4411f, new DateTime(2022, 8, 10)));
        profiles.Add(new Profile("b", 28.4411f, new DateTime(2022, 8, 10)));
        profiles.Add(new Profile("c", 16.4411f, new DateTime(2022, 8, 10)));
        profiles.Add(new Profile("d", 33.4411f, new DateTime(2022, 8, 10)));
        profiles.Add(new Profile("e", 28.4001f, new DateTime(2022, 8, 8)));
        profiles.Add(new Profile("f", 17.4411f, new DateTime(2022, 8, 8)));
        profiles.Add(new Profile("g", 31.4411f, new DateTime(2022, 8, 8)));
        profiles.Add(new Profile("h", 27.4411f, new DateTime(2022, 7, 8)));
        profiles.Add(new Profile("i", 11.4411f, new DateTime(2022, 7, 8)));
        profiles.Add(new Profile("j", 30.4411f, new DateTime(2022, 7, 8)));

    }

    

    public static void ChangeRecord(string name, float time)
    {
        Profile currentProfile = GetRecord(name);

        if(currentProfile!=null)
        {
            if(currentProfile.time>time)
            {
                currentProfile.time = time;
                currentProfile.date = DateTime.Today;
            }
        }
        else
        {
            profiles.Add(new Profile(name, time, DateTime.Today));
        }
        SaveData();
    }

    public static Profile GetRecord(string name)
    {
        for (int i = 0; i < profiles.Count; i++)
        {
            if (profiles[i].name == name)
            {
                return profiles[i];
            }
        }
        return null;
    }

    public static List<Profile> GetData()
    {
        return profiles;
    }
}
