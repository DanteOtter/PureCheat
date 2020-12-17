using UnityEngine;
using PureCheat.API;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class PlayerTeleport : PureModSystem
    {
        public override string ModName => "Teleport to player";

        public override void OnStart()
        {
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Teleport", "Teleport to player",
                ButtonAPI.HorizontalPosition.FirstButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("UserUtils").transform, delegate (bool a)
                {
                    PureUtils.GetLocalPlayer().transform.position = PureUtils.GetSelectedPlayerOrNull().gameObject.transform.position;
                }, Color.white, Color.white, null, false, false);
        }
    }
}
