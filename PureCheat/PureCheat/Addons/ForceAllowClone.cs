using VRC;
using UnityEngine;
using PureCheat.API;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class ForceAllowClone : PureModSystem
    {
        public override string ModName => "Force clone avatar";

        public override void OnStart()
        {
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Allow Clone", "Allow to clone all avatars",
                ButtonAPI.HorizontalPosition.SecondButtonPos, ButtonAPI.VerticalPosition.SecondButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    foreach (Player player in PureUtils.GetPlayers())
                        player.prop_APIUser_0.allowAvatarCopying = true;
                }, Color.white, Color.white, null, false, false);
        }
    }
}
