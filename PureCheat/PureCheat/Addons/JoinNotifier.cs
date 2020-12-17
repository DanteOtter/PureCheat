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
            PureLogger.Log($"{playerName} joined room!");
        }

        public override void OnPlayerLeave(Player player)
        {
            string playerName = player.gameObject.GetComponent<VRCPlayer>().ToString();
            PureLogger.Log($"{playerName} leaved room!");
        }
    }
}
