using System;
using UnityEngine;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class Support : PureModSystem
    {
        public override string ModName => "Support";

        public static QMSingleButton DonateButton;

        public override void OnStart()
        {
            DonateButton = new QMSingleButton(QMUI.UIMenuP3, 5, 0, "Support", new Action(() =>
            {
                PureLogger.Log("Thanks for support!");
            }), "Support author!", Color.yellow, Color.green);
        }
    }
}
