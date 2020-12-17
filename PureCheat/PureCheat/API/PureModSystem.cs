namespace PureCheat.API
{
    public class PureModSystem
    {
        public virtual string ModName => "Default Mod";
        public virtual void OnEarlierStart() { }
        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnLateUpdate() { }
        public virtual void OnPlayerJoin(VRC.Player player) { }
        public virtual void OnPlayerLeave(VRC.Player player) { }
        public virtual void OnGUI() { }
        public virtual void OnQuit() { }
    }
}
