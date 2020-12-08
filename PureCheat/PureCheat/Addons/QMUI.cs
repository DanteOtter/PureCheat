using RubyButtonAPI;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class QMUI : PureModSystem
    {
        public override string ModName => "QuickMenu Utils";

        public static QMNestedButton UIMenuP1;
        public static QMNestedButton UIMenuP2;
        public static QMNestedButton UIMenuP3;

        public override void OnStart()
        {
            UIMenuP1 = new QMNestedButton("ShortcutMenu", 0, 0, "Pure\nMenu", "PureCheat Menu");
            UIMenuP2 = new QMNestedButton(UIMenuP1, 5, 1, "Page 2", "Second Page");
            UIMenuP3 = new QMNestedButton(UIMenuP2, 5, 1, "Page 3", "Third Page");
        }
    }
}
