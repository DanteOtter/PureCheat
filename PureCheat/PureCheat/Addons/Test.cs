using System;
using UnityEngine;
using PureCheat.API;
using PureCheat.Forms;

namespace PureCheat.Addons
{
    public class Test : PureModSystem
    {
        public override string ModName => "Test";

        public static QMSingleButton testCallFormButton;

        public override void OnStart()
        {
            testCallFormButton = new QMSingleButton(QMUI.UIMenuP1, 5, 0, "Call\nForm", new Action(()=>
            {
                System.Windows.Forms.Application.Run(new TPForm());
            }), "Call Test Form");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.U))
                foreach (GameObject gameObject in PureUtils.GetAllGameObjects())
                    PureLogger.Log($"Name: [{gameObject.transform.name}] | Pos: ({gameObject.transform.position.x}, {gameObject.transform.position.y}, {gameObject.transform.position.z})");

            if (Input.GetKeyDown(KeyCode.T))
                foreach (GameObject gameObject in PureUtils.GetAllObjectsInSceneTree())
                    PureLogger.Log($"Name: [{gameObject.transform.name}] | Pos: ({gameObject.transform.position.x}, {gameObject.transform.position.y}, {gameObject.transform.position.z})");

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
        }
    }
}
