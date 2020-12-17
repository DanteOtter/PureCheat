using UnityEngine;
using PureCheat.API;
using UnityEngine.UI;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class SnowTime : PureModSystem
    {
        public override string ModName => "Snow time";

        private bool toggleState = false;
        private Button snowEmojiButton = null;


        public override void OnStart()
        {
            snowEmojiButton = GameObject.Find("UserInterface/QuickMenu/EmojiMenu/Page5/EmojiButton2").GetComponent<Button>();

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "Snow Time!", "Toggle spam snow emoji",
                ButtonAPI.HorizontalPosition.FirstButtonPos, ButtonAPI.VerticalPosition.SecondButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    toggleState = a;
                }, Color.white, Color.cyan, null, false, false);
        }

        public override void OnUpdate()
        {
            if (toggleState)
                snowEmojiButton.onClick.Invoke();
        }
    }
}
