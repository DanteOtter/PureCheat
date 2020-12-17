using UnityEngine;
using PureCheat.API;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class AlwaysInfo : PureModSystem
    {
        public override string ModName => "Always trust info";

        private bool toggleQuickInfo = false;

        public override void OnStart()
        {
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "Quck Info!", "Toggle quick info on players",
                ButtonAPI.HorizontalPosition.ThirdButtonPos, ButtonAPI.VerticalPosition.SecondButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    toggleQuickInfo = a;
                }, Color.white, Color.yellow, null, false, false);
        }
    }
}
