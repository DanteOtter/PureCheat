using UnityEngine;
using VRC.SDKBase;
using PureCheat.API;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class ReJoinInstance : PureModSystem
    {
        public override string ModName => "Rejoin instance";

        public override void OnStart()
        {
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Reconnect", "Reconnect to instance", 
                ButtonAPI.HorizontalPosition.ThirdButtonPos, ButtonAPI.VerticalPosition.SecondButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    Networking.GoToRoom(PureUtils.GetInstance().instanceWorld.id + ":" + PureUtils.GetInstance().instanceWorld.currentInstanceIdWithTags);
                }, Color.white, Color.white, null, false, false);
        }
    }
}
