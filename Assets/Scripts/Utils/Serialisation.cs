using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


public struct SerialisationData
{
    public SaveData data;
}


public static class Serialisation
{
    public static void Save(SaveData saveData)
    {
        var serialisationData = new SerialisationData();
        serialisationData.data = saveData;

        var json = JsonConvert.SerializeObject(serialisationData);

        System.IO.File.WriteAllText(Application.persistentDataPath + "/savedData.json", json);
    }

    public static SerialisationData Load()
    {
        var path = Application.persistentDataPath + "/savedData.json";
        if (System.IO.File.Exists(path))
        {
            var json = System.IO.File.ReadAllText(path);
            var data = JsonConvert.DeserializeObject<SerialisationData>(json);
            return data;
        }

        throw new System.Exception("Error no data can be found");
    }

    public static void ClearSave()
    {
        var path = Application.persistentDataPath + "/savedData.json";
        if (System.IO.File.Exists(path))
        {

            System.IO.File.Delete(path);
        }

    }

    public static bool HasCurrentSave()
    {
        var path = Application.persistentDataPath + "/savedData.json";
        return System.IO.File.Exists(path);
    }
}
