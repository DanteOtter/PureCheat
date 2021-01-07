using UnityEngine;
using PureCheat.API;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class ESP : PureModSystem
    {
        public override string ModName => "ESP";
        private bool toggleESP = false;
        private Il2CppSystem.Collections.Generic.List<VRC.Player> localList = new Il2CppSystem.Collections.Generic.List<VRC.Player>();
        private GameObject localPlayer;

        public override void OnStart()
        {
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "ESP", "ESP",
                ButtonAPI.HorizontalPosition.SecondButtonPos, ButtonAPI.VerticalPosition.SecondButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    toggleESP = a;

                    localList = PureUtils.GetPlayers();
                    localPlayer = PureUtils.GetLocalPlayer();
                }, Color.white, Color.cyan, null);
        }

        public override void OnGUI()
        {
            if (toggleESP)
                foreach (VRC.Player player in localList)
                    Gizmos.DrawLine(localPlayer.transform.position + Vector3.up, player.transform.position);
        }
    }
}
