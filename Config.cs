using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
namespace EmptyMod
{
    public class Config
    {
        public Config(EmptyMod.ModMain modInsance)
        {
            mod = modInsance;
            settings = new ModSettings();
        }

        public void Load()
        {
            try
            {
                if (File.Exists(mod.ConfigPath))
                    using (var streamReader = new StreamReader(mod.ConfigPath))
                    {
                        //NOTE: This is NOT doing anything related to saved games, we're just using some of the game's serialization utilities.
                        var ctx = new SerializationContext(SerializationContext.Context.Savegame);
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            //Parkitect's Serializer handles copyping properties from the Json dictionary to the stronger typed ModSettings object.
                            Serializer.deserialize(ctx, settings, (Dictionary<string, object>) Json.Deserialize(line));
                        }
                        streamReader.Close();
                    }
            }
            catch (Exception e)
            {
                Debug.Log("[NullMod] Error loading settings: " + e);
            }
        }
        
        public void Save()
        {
            using (var fileStream = new FileStream(mod.ConfigPath, FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    var ctx = new SerializationContext(SerializationContext.Context.Savegame);
                    streamWriter.WriteLine(Json.Serialize(Serializer.serialize(ctx, settings)));
                }
            }

        }

        public void onDrawUI()
        {
            //TODO
            GUILayout.Label("I'm a label");

            GUILayout.Button("A button that does nothing!");

            GUILayout.BeginHorizontal();
            settings.someBool = GUILayout.Toggle(settings.someBool, "Some Boolean");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Zero to One:");
            settings.someFloat = GUILayout.HorizontalSlider(settings.someFloat, 0.0f, 1.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("A String:");
            settings.someText = GUILayout.TextField(settings.someText);
            GUILayout.EndHorizontal();
        }

        public ModSettings settings { get; }
        public EmptyMod.ModMain mod { get; }
    }

    public class ModSettings: SerializedRawObject
    {
        public ModSettings()
        {
            someBool = false;
            someFloat = 0;
            someText = "";
        }

        [Serialized] public bool someBool { get; set; }
        [Serialized] public float someFloat { get; set; }
        [Serialized] public string someText { get; set; }
    }
}
