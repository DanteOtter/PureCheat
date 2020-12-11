using System;
using PureCheat.API;
using RubyButtonAPI;

namespace PureCheat.Addons
{
    public class Jump : PureModSystem
    {
        public override string ModName => "Jump";

        public static QMSingleButton addJumpButton;

        public override void OnStart()
        {
            addJumpButton = new QMSingleButton(QMUI.UIMenuP1, 3, 0, "Add\nJump", new Action(() =>
            {
                if (PureUtils.GetLocalPlayer().GetComponent<PlayerModComponentJump>())
                    return;
                else
                    PureUtils.GetLocalPlayer().AddComponent<PlayerModComponentJump>();

                PureUtils.GetLocalPlayer().GetComponent<PlayerModComponentJump>().field_Private_Single_0 = 2.0f;
                PureUtils.GetLocalPlayer().GetComponent<PlayerModComponentJump>().field_Private_Single_1 = 2.0f;
            }), "Add jump component to player");
        }
    }
}
