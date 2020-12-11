using UnityEngine;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class RemoveItems : PureModSystem
    {
        public override string ModName => "Remove items";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(1) && Input.GetMouseButtonDown(0))
            {
                GameObject playerCamera = PureUtils.GetLocalPlayerCamera();

                Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
                RaycastHit[] hits = Physics.RaycastAll(ray);
                if (hits.Length > 0)
                {
                    RaycastHit raycastHit = hits[0];
                    GameObject.Destroy(raycastHit.transform.gameObject);
                }
            }
        }
    }
}
