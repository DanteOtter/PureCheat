using PureCheat.API;

namespace PureCheat.Addons
{
    public class FPSUnlimiter : PureModSystem
    {
        public override string ModName => "FPS Unlimiter";

        public override void OnEarlierStart() =>
            UnityEngine.Application.targetFrameRate = 300;
    }
}
