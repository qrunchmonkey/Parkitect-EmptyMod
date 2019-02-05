using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EmptyMod
{
    public class ModMain : IMod
    {
        // Mod Metadata
        public string Name => "Empty Mod";

        public string Description => "This is a skeleton of a mod for Parkitect 1.2 or higher.";

        string IMod.Identifier => "com.krisharris.nullmod";

        // Helpers
        public string ModPath
        {
            get
            {
                return ModManager.Instance.getModEntries().First(x => x.mod == this).path;
            }
        }

        // IMod handler
        public void onEnabled()
        {
            //TODO: Add code to load and setup your new mod
            Debug.Log((object)"Loaded Empty Mod!");
        }

        public void onDisabled()
        {
            //TODO: Add code to disable your mod.
            Debug.Log((object)"Unloaded Empty Mod!");
        }


    }
}
