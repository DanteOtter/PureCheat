using System;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class Donation : PureModSystem
    {
        public override string ModName => "Support";

        public static QMSingleButton DonateButton;

        public override void OnStart()
        {
            DonateButton = new QMSingleButton(QMUI.UIMenuP1, 0, 2, "Support", new Action(() =>
            {
                PureLogger.Log("Thanks for support!");
            }), "Support author!");
        }
    }
}
