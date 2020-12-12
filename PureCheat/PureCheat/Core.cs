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
            PureLogger.Init();

            Mods.Add(new QMUI());

            Mods.Add(new Fly());
            Mods.Add(new Jump());
            Mods.Add(new VRCMin());
            Mods.Add(new EarRape());
            Mods.Add(new FastQuit());
            Mods.Add(new FOVChanger());
            Mods.Add(new RemoveItems());
            Mods.Add(new RayTeleport());
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
            foreach (PureModSystem mod in Mods)
                mod.OnStart();
        }

        public override void OnUpdate()
        {
            foreach (PureModSystem mod in Mods)
                mod.OnUpdate();
        }

        public override void OnLateUpdate()
        {
            foreach (PureModSystem mod in Mods)
                mod.OnLateUpdate();
        }

        public override void OnFixedUpdate()
        {
            foreach (PureModSystem mod in Mods)
                mod.OnFixedUpdate();
        }

        public override void OnGUI()
        {
            foreach (PureModSystem mod in Mods)
                mod.OnGUI();
        }

        public override void OnApplicationQuit()
        {
            foreach (PureModSystem mod in Mods)
                mod.OnQuit();
        }
    }
}
