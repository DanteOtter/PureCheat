using VRC;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class JoinNotifier : PureModSystem
    {
        public override string ModName => "Join notifier";

        public override void OnPlayerJoin(Player player)
        {
            string playerName = player.gameObject.GetComponent<VRCPlayer>().ToString();
            PureLogger.Log($"{player.field_Private_APIUser_0.displayName} joined the room!");
        }

        public override void OnPlayerLeave(Player player)
        {
            string playerName = player.gameObject.GetComponent<VRCPlayer>().ToString();
            PureLogger.Log($"{player.field_Private_APIUser_0.displayName} left the room!");
        }
    }
}
