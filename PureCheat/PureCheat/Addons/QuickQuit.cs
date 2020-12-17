using UnityEngine;
using System.Timers;
using PureCheat.API;
using UnityEngine.UI;
using PlagueButtonAPI;
using System.Diagnostics;
using System;

namespace PureCheat.Addons
{
    public class QuickQuit : PureModSystem
    {
        public override string ModName => "Quick quit";

        private GameObject killButton = null;

        public override void OnStart()
        {
            killButton = ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Quit", "Shutdown game",
                ButtonAPI.HorizontalPosition.ThirdButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    Application.Quit();

                    Timer aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Interval = 800;
                    aTimer.Enabled = true;

                }, Color.red, Color.red, null);
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F3))
                killButton.GetComponent<Button>().onClick.Invoke();
        }
    }
}
