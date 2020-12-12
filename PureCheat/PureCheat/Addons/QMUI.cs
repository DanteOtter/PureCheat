using UnityEngine;
using PureCheat.API;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class QMUI : PureModSystem
    {
        public override string ModName => "QuickMenu Utils";

        // ▲▼

        public override void OnStart()
        {
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Pure\nCheat", "Pure cheat menu",
                ButtonAPI.HorizontalPosition.LeftOfMenu, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.ShortcutMenuTransform, delegate (bool a)
                {
                    ButtonAPI.EnterSubMenu(ButtonAPI.MakeEmptyPage("PureCheat"));
                }, Color.white, Color.white, null, true, false, false, false, null, true);

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Player List", "Player list menu",
                ButtonAPI.HorizontalPosition.FirstButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    ButtonAPI.EnterSubMenu(ButtonAPI.MakeEmptyPage("PlayerList"));
                }, Color.white, Color.white, null, false, true, false, false, null, true);
        }
    }
}
