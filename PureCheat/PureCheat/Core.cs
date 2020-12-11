using MelonLoader;
using PureCheat.API;
using PureCheat.Addons;
using System.Collections.Generic;

namespace PureCheat
{
    public class Core : MelonMod
    {
        public static List<PureModSystem> Mods = new List<PureModSystem>();
        
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            PureLogger.Init();

            Mods.Add(new QMUI());

            Mods.Add(new Fly());
            Mods.Add(new Jump());
            Mods.Add(new Test());
            Mods.Add(new Support());
            Mods.Add(new FuckVRC());
            Mods.Add(new EarRape());
            Mods.Add(new FuckPlus());
            Mods.Add(new HideMenu());
            Mods.Add(new FOVChanger());
            Mods.Add(new RayTeleport());
            Mods.Add(new RemoveItems());
            Mods.Add(new FPSUnlimiter());
            Mods.Add(new PlayerTeleport());

            foreach (PureModSystem mod in Mods)
            {
                mod.OnEarlierStart();
                PureLogger.Log($"{mod.ModName} loaded!");
            }
        }

        public override void VRChat_OnUiManagerInit()
        {
            base.VRChat_OnUiManagerInit();

            GlobalVariables.isVRCUILoaded = true;

            foreach (PureModSystem mod in Mods)
                mod.OnStart();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            foreach (PureModSystem mod in Mods)
                mod.OnUpdate();
        }

        public override void OnLateUpdate()
        {
            base.OnLateUpdate();

            foreach (PureModSystem mod in Mods)
                mod.OnLateUpdate();
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            foreach (PureModSystem mod in Mods)
                mod.OnFixedUpdate();
        }

        public override void OnGUI()
        {
            base.OnGUI();

            foreach (PureModSystem mod in Mods)
                mod.OnGUI();
        }

        public override void OnApplicationQuit()
        {
            base.OnApplicationQuit();

            foreach (PureModSystem mod in Mods)
                mod.OnQuit();
        }
    }
}
