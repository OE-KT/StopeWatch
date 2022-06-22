using BepInEx;
using System;
using UnityEngine;
using Utilla;
using System.IO;
using System.Reflection;
namespace stopwatch
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
      public static GameObject watch;
      public static Sprite playimg;
        public static Sprite paseimg;
        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
            Utilla.Events.GameInitialized -= OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            Utils.RefCache.LeftHandFollower = GorillaLocomotion.Player.Instance.leftHandFollower.gameObject;
            Utils.RefCache.RightHandFollower = GorillaLocomotion.Player.Instance.rightHandFollower.gameObject;
            Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("stopwatch.Assets.watch");
            AssetBundle bundle = AssetBundle.LoadFromStream(str);
            GameObject watch = bundle.LoadAsset<GameObject>("watch");
            playimg = bundle.LoadAsset<Sprite>("play");
            paseimg = bundle.LoadAsset<Sprite>("pase");
            watch = Instantiate(watch);
            GameObject buttonPan = GameObject.Find("watch(Clone)/bnt");
            
            Transform[] allChildren;
            allChildren = buttonPan.GetComponentsInChildren<Transform>();
            foreach (Transform button in allChildren)
            {

                button.gameObject.AddComponent<stopwatch.Conponts.HandTrigger>();
                
            }
            watch.AddComponent<stopwatch.Conponts.watch>();
            watch.transform.Find("bnt/play").gameObject.AddComponent<stopwatch.Conponts.StartAndstop>();
            watch.transform.Find("bnt/Lap").gameObject.AddComponent<stopwatch.Conponts.LapandReset>();
            
            
           
            
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
        }

        void Update()
        {
            /* Code here runs every frame when the mod is enabled */
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            /* Activate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = false;
        }
    }
}
