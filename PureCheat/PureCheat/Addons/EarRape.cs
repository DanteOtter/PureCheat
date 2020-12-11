using System;
using UnityEngine;
using PureCheat.API;
using RubyButtonAPI;

namespace PureCheat.Addons
{
    public class EarRape : PureModSystem
    {

        public override string ModName => "EarRape";

        public static QMToggleButton toggleEarRape;

        public override void OnStart()
        {
            toggleEarRape = new QMToggleButton(QMUI.UIMenuP1, 4, 0,
            "EarRape ON", new Action(() =>
            {
                USpeaker.field_Internal_Static_Single_1 = float.MaxValue;
                PureLogger.Log(ConsoleColor.Red, "EarRape Enabled");
            }), "EarRape OFF", new Action(() =>
            {
                USpeaker.field_Internal_Static_Single_1 = 1f;
                PureLogger.Log(ConsoleColor.Green, "EarRape Disabled");
            }), "Toggle EarRape");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F9))
                if (USpeaker.field_Internal_Static_Single_1 <= 1f)
                {
                    toggleEarRape.setToggleState(true);
                    USpeaker.field_Internal_Static_Single_1 = float.MaxValue;
                    PureLogger.Log(ConsoleColor.Red, "EarRape Enabled");
                }
                else
                {
                    toggleEarRape.setToggleState(false);
                    USpeaker.field_Internal_Static_Single_1 = 1f;
                    PureLogger.Log(ConsoleColor.Green, "EarRape Disabled");
                }
        }
    }
}
