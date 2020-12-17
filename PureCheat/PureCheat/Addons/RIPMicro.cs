using UnityEngine;
using PureCheat.API;
using UnityEngine.UI;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class RIPMicro : PureModSystem
    {
        public override string ModName => "RIP microphone";

        private bool toggleState = false;
        private Button micButton = null;


        public override void OnStart()
        {
            //UserInterface/QuickMenu/EmojiMenu/Page5/EmojiButton2
            micButton = GameObject.Find("UserInterface/QuickMenu/MicControls/MicButton").GetComponent<Button>();

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "RIP Mic", "Fast toggle microphone",
                ButtonAPI.HorizontalPosition.FourthButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    toggleState = a;
                }, Color.white, Color.red, null);
        }

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.V))
                toggleState = !toggleState;

            if (toggleState)
                micButton.onClick.Invoke();
        }
    }
}
