using MelonLoader;
using PureCheat.API;
using System.Collections;
using System.Collections.Generic;

namespace PureCheat
{
    public class Core : MelonMod
    {
        public static List<PureModSystem> Mods = new List<PureModSystem>();

        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(InitMod());
        }

        public IEnumerator InitMod()
        {
            while (ReferenceEquals(NetworkManager.field_Internal_Static_NetworkManager_0, null)) yield return null;
            NetworkManagerHooks.Initialize();
            PureLogger.Init();

            Mods.Add(new Addons.QMUI());

            Mods.Add(new Addons.Fly());
            Mods.Add(new Addons.ESP());
            Mods.Add(new Addons.Jump());
            Mods.Add(new Addons.VRCMin());
            Mods.Add(new Addons.Players());
            Mods.Add(new Addons.EarRape()); // not for public version
            Mods.Add(new Addons.SnowTime());
            Mods.Add(new Addons.BeerTime());
            Mods.Add(new Addons.RIPMicro()); // not for public version
            Mods.Add(new Addons.QuickQuit()); // not for public version
            //Mods.Add(new Addons.AlwaysInfo()); // FIX!
            Mods.Add(new Addons.FOVChanger());
            Mods.Add(new Addons.RemoveItems()); // not for public version
            Mods.Add(new Addons.RayTeleport());
            Mods.Add(new Addons.JoinNotifier());
            Mods.Add(new Addons.FPSUnlimiter());
            Mods.Add(new Addons.DownloadVRCA());
            Mods.Add(new Addons.QuickRespawn());
            Mods.Add(new Addons.ReJoinInstance());
            Mods.Add(new Addons.PlayerTeleport());
            Mods.Add(new Addons.OptimizeMirrors());
            Mods.Add(new Addons.ForceAllowClone());
            //Mods.Add(new Addons.UnlimitedAvatarFavorite()); // FIX!

            foreach (PureModSystem mod in Mods)
            {
                PureLogger.Log($"{mod.ModName} loaded!");
                mod.OnEarlierStart();
            }

            NetworkManagerHooks.OnJoin += NetworkManagerHooks_OnJoin;
            NetworkManagerHooks.OnLeave += NetworkManagerHooks_OnLeave;
        }

            private void NetworkManagerHooks_OnJoin(VRC.Player player)
        {
            foreach (PureModSystem mod in Mods)
                mod.OnPlayerJoin(player);
        }

        private void NetworkManagerHooks_OnLeave(VRC.Player player)
        {
            foreach (PureModSystem mod in Mods)
                mod.OnPlayerLeave(player);
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
