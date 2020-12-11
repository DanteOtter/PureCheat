using System;
using UnityEngine;
using RubyButtonAPI;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class HideMenu : PureModSystem
    {
        public override string ModName => "Hide Menu";

        public static bool MenuHiddenState = false;
        public static QMSingleButton hideClientButton;

        public override void OnStart()
        {
            hideClientButton = new QMSingleButton(QMUI.UIMenuP1, 0, 0, "Hide\nClient\nMenu", new Action(() =>
            {
                MenuHiddenState = !MenuHiddenState;

                if (MenuHiddenState)
                    hideClientButton.setButtonText("Hide\nClient\nMenu");
                else
                    hideClientButton.setButtonText("Show\nClient\nMenu");

                QMUI.UIMenuP1.getMainButton().setActive(MenuHiddenState);
            }), "Hide This Menu [H]");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.H) && GlobalVariables.isVRCUILoaded)
            {
                MenuHiddenState = !MenuHiddenState;

                if (MenuHiddenState)
                    hideClientButton.setButtonText("Hide\nClient\nMenu");
                else
                    hideClientButton.setButtonText("Show\nClient\nMenu");

                QMUI.UIMenuP1.getMainButton().setActive(MenuHiddenState);           
            }
        }
    }
}
