using UnityEngine;
using PureCheat.API;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class VRCMin : PureModSystem
    {
        public override string ModName => "VRC Minus";

        public override void OnStart()
        {
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "VRChat -", "Toggle Remove VRC+",
                ButtonAPI.HorizontalPosition.ThirdButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
            {
                GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/UserIconButton").SetActive(!a);
                GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusMiniBanner/Image").SetActive(!a);
                GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/User Panel/Supporter").SetActive(!a);
                GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/AvatarImage/SupporterIcon").SetActive(!a);
                GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBanner/Panel").SetActive(!a);
                GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/User Panel/VRCPlusEarlyAdopter").SetActive(!a);
                GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/VRC+PageTab").SetActive(!a);
                GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/UserIconTab").SetActive(!a);
                GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Favorite Avatar List/GetMoreFavorites").SetActive(!a);
            }, Color.yellow, Color.red, null, false, false);
        }
    }
}
