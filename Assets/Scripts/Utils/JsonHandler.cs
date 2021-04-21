using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public static class JsonHandler
{

    public static T LoadFromJSON<T>(string name)
    {
        var json = Resources.Load<TextAsset>("JSON/" + name);
        var settings = new JsonSerializerSettings();
        settings.MissingMemberHandling = MissingMemberHandling.Error;
        settings.DefaultValueHandling = DefaultValueHandling.Ignore;

        var loaded = JsonConvert.DeserializeObject<T>(json.text, settings);

        // ExtensionsHandy.CheckJSON(loaded, name);

        return loaded;
    }
}
