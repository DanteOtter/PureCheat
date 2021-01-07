using UnityEngine;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class Players : PureModSystem
    {
        public override string ModName => "Players";

        private Il2CppSystem.Collections.Generic.List<VRC.Player> localList = new Il2CppSystem.Collections.Generic.List<VRC.Player>();
        private bool toggleNames = false;

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.P))
            {
                toggleNames = !toggleNames;
                
                if (toggleNames)
                    localList = PureUtils.GetPlayers();
            }
        }

        public override void OnGUI()
        {
            if (toggleNames && QMUI.isUIInit)
                for (int i = 0; i < localList.Count; i++)
                    if (GUI.Button(new Rect(10f, 30f * (i + 1), 500f, 25f), $"{localList[i].prop_APIUser_0.displayName} | {localList[i].prop_APIUser_0.username}"))
                        PureUtils.GetLocalPlayer().transform.position = localList[i].gameObject.transform.position;
        }
    }
}
