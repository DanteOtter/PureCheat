using UnityEngine;
using PureCheat.API;
using UnityEngine.UI;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class BeerTime : PureModSystem
    {
        public override string ModName => "Snow time";

        private bool toggleState = false;
        private Button beerEmojiButton = null;


        public override void OnStart()
        {
            beerEmojiButton = GameObject.Find("UserInterface/QuickMenu/EmojiMenu/Page2/EmojiButton2").GetComponent<Button>();

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "Beer Time!", "Toggle spam snow emoji",
                ButtonAPI.HorizontalPosition.FirstButtonPos, ButtonAPI.VerticalPosition.SecondButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    toggleState = a;
                }, Color.white, Color.yellow, null, false);
        }

        public override void OnUpdate()
        {
            if (toggleState)
                beerEmojiButton.onClick.Invoke();
        }
    }
}
