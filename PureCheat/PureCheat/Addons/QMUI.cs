using UnityEngine;
using PureCheat.API;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class QMUI : PureModSystem
    {
        public override string ModName => "QuickMenu Utils";
        public static bool isUIInit = false;

        // ▲▼
        public override void OnStart()
        {
            //Change QM collider size [for more buttons]
            GameObject.Find("UserInterface/QuickMenu").GetComponent<BoxCollider>().size = new Vector3(5034.68f, 3342.426f, 1f);

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Pure\nCheat", "Pure cheat menu",
                ButtonAPI.HorizontalPosition.LeftOfMenu, ButtonAPI.VerticalPosition.AboveTopButton, ButtonAPI.ShortcutMenuTransform, delegate (bool a)
                {
                    ButtonAPI.EnterSubMenu(ButtonAPI.MakeEmptyPage("PureCheat"));
                }, Color.white, Color.white, null, true, false, false, false, null, true);

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Player List", "Player list menu",
                ButtonAPI.HorizontalPosition.FirstButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    ButtonAPI.EnterSubMenu(ButtonAPI.MakeEmptyPage("PlayerList"));
                }, Color.white, Color.white, null, false, true, false, false, null, true);

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "User\nUtils", "User utils menu [PureCheat]",
                ButtonAPI.HorizontalPosition.TwoLeftOfMenu, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.UserInteractMenuTransform, delegate (bool a)
                {
                    ButtonAPI.EnterSubMenu(ButtonAPI.MakeEmptyPage("UserUtils"));
                }, Color.white, Color.white, null, true);

            isUIInit = true;
        }

        public override void OnUpdate()
        {
            if (isUIInit)
                ButtonAPI.SubMenuHandler();
        }
    }
}
