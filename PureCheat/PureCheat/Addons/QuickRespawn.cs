using UnityEngine;
using PureCheat.API;
using UnityEngine.UI;

namespace PureCheat.Addons
{
    public class QuickRespawn : PureModSystem
    {
        public override string ModName => "Quick respawn";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.Alpha1))
                GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/RespawnButton").GetComponent<Button>().onClick.Invoke();
        }
    }
}
