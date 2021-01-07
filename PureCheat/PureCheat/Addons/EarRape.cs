using System;
using UnityEngine;
using UnityEngine.UI;
using PureCheat.API;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class EarRape : PureModSystem
    {

        public override string ModName => "EarRape";

        private ButtonAPI.PlagueButton earRapeButton;

        public override void OnStart()
        {
             earRapeButton = ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "EarRape", "FUCK ALL EARS",
                ButtonAPI.HorizontalPosition.FourthButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    USpeaker.field_Internal_Static_Single_1 = a ? float.MaxValue : 1f;
                    PureLogger.Log(a ? ConsoleColor.Red : ConsoleColor.Green, a ? "EarRape Enabled" : "EarRape Disabled");
                }, Color.white, Color.red, null, false, false, false, false, null, true);
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F9))
                earRapeButton.button.onClick.Invoke();
        }
    }
}
