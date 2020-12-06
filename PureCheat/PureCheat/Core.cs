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

            Mods.Add(new Fly());
            Mods.Add(new Test());
            Mods.Add(new RayTeleport());

            foreach (PureModSystem mod in Mods)
                mod.OnEarlierStart();
        }

        public override void VRChat_OnUiManagerInit()
        {
            base.VRChat_OnUiManagerInit();

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
