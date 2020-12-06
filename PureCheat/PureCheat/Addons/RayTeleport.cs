using System;
using PureCheat.API;
using UnityEngine;

namespace PureCheat.Addons
{
    class RayTeleport : PureModSystem
    {
        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
            {
                GameObject player = PureUtils.GetLocalPlayer();

                Ray ray = new Ray(PureUtils.GetLocalPlayerCamera().transform.position, PureUtils.GetLocalPlayerCamera().transform.forward);
                RaycastHit[] hits = Physics.RaycastAll(ray);
                if (hits.Length > 0)
                {
                    RaycastHit raycastHit = hits[0];
                    PureUtils.GetLocalPlayer().transform.position = raycastHit.point;
                }
            }
        }
    }
}
