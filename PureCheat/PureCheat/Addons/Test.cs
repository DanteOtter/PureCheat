using UnityEngine;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class Test : PureModSystem
    {
        public override string ModName => "Test";

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                foreach (GameObject gameObject in PureUtils.GetAllGameObjects())
                    PureLogger.Log($"Name: [{gameObject.transform.name}] | Pos: {gameObject.transform.position}");
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                PureUtils.GetLocalPlayer().transform.position += PureUtils.GetLocalPlayer().transform.forward * 2f;
            }
        }
    }
}
