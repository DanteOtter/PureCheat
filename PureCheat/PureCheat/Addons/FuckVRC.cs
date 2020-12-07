using System;
using UnityEngine;
using PureCheat.API;
using System.Diagnostics;

namespace PureCheat.Addons
{
    public class FuckVRC : PureModSystem
    {
        public override string ModName => "Fuck VRChat";

        public static QMSingleButton fuckVRCButton;

        public override void OnStart()
        {
            fuckVRCButton = new QMSingleButton(QMUI.UIMenuP2, 5, 0, "Fuck\nVRChat", new Action(() =>
            {
                Process.GetCurrentProcess().Kill();
            }), "Fuck VRChat НАХУЙ!", Color.red, Color.red);
        }

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F3))
                Process.GetCurrentProcess().Kill();
        }
    }
}
