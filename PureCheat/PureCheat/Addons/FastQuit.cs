using UnityEngine;
using PureCheat.API;
using UnityEngine.UI;
using PlagueButtonAPI;
using System.Diagnostics;

namespace PureCheat.Addons
{
    public class FastQuit : PureModSystem
    {
        public override string ModName => "Fast quit";

        private GameObject killButton = null;

        public override void OnStart()
        {
            killButton = ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Quit", "Shutdown game",
                ButtonAPI.HorizontalPosition.ThirdButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    Application.Quit();
                    Process.GetCurrentProcess().Kill();
                }, Color.red, Color.red, null);
        }

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F3))
                killButton.GetComponent<Button>().onClick.Invoke();
        }
    }
}
