using UnityEngine;
using PureCheat.API;
using PlagueButtonAPI;
using System.Diagnostics;

namespace PureCheat.Addons
{
    public class DownloadVRCA : PureModSystem
    {
        public override string ModName => "Download VRCA";

        public override void OnStart()
        {
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Get VRCA", "Download VRCA of Player", 
                ButtonAPI.HorizontalPosition.SecondButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("UserUtils").transform, delegate (bool a)
                {
                    Process.Start(Wrapper.GetQuickMenu().GetSelectedPlayer().field_Internal_VRCPlayer_0.prop_ApiAvatar_0.assetUrl);
                }, Color.white, Color.white, null, false, false);
        }
    }
}
