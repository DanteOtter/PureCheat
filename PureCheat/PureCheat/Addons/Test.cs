using System;
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

            if (Input.GetKeyDown(KeyCode.I))
            {
                GameObject playerCamera = PureUtils.GetLocalPlayerCamera();

                Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
                RaycastHit[] hits = Physics.RaycastAll(ray);
                if (hits.Length > 0)
                {
                    RaycastHit raycastHit = hits[0];
                    PureLogger.Log(raycastHit.transform.name);
                }
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                PureUtils.GetLocalPlayer().transform.position += PureUtils.GetLocalPlayer().transform.forward * 2f;
            }
        }
    }
}
