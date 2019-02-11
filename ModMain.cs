using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EmptyMod
{
    public class ModMain : IMod, IModSettings
    {
        public ModMain()
        {
            Name = "Empty Mod";
            Description = "This is a skeleton of a mod for Parkitect 1.2 or higher.";
            Identifier = "com.krisharris.nullmod"; //Reverse DNS is best for identifiers, but anything unique works.

            Config = new Config(this);
            Config.Load();
        }

        public string Name { get; }
        public string Description { get; }
        public string Identifier { get; }
        public EmptyMod.Config Config { get; }
        // Helpers
        public string ModDir
        {
            get
            {
                return ModManager.Instance.getModEntries().First(x => x.mod == this).path;
            }
        }

        public string ConfigPath
        {
            get
            {
                return FilePaths.getFolderPath(Identifier + ".config");
            }
        }

        // IMod handler
        public void onEnabled()
        {
            Config.Load();
            Config.Save();

            //TODO: Add code to load and setup your new mod
            Debug.Log("[EmptyMod]: Enabled!");
        }

        public void onDisabled()
        {
            //TODO: Add code to disable your mod.
            Debug.Log("[EmptyMod]: Disabled!");
        }

        //IModSettings handler

        public void onSettingsOpened()
        {
            Debug.Log("[EmptyMod]: Settings Opened");
        }

        public void onSettingsClosed()
        {
            Config.Save();
            Debug.Log("[EmptyMod]: Settings Closed");
        }

        public void onDrawSettingsUI()
        {
            Config.onDrawUI();
        }

    }
}
