using UnityEngine;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class Fly : PureModSystem
    {
        public override string ModName => "Fly";

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Vars.isFly = !Vars.isFly;
                if (Vars.isFly)
                {
                    PureUtils.GetLocalPlayer().GetComponent<CharacterController>().enabled = false;
                    PureLogger.Log("Fly has been Enabled");
                }
                else
                {
                    PureUtils.GetLocalPlayer().GetComponent<CharacterController>().enabled = true;
                    PureLogger.Log("Fly has been Disabled");
                }
            }

            if (Vars.isFly)
            {
                GameObject player = PureUtils.GetLocalPlayer();
                GameObject playercamera = PureUtils.GetLocalPlayerCamera();

                if (Vars.flySpeed <= 0)
                    Vars.flySpeed = 1;

                if (Input.mouseScrollDelta.y != 0)
                {
                    Vars.flySpeed += (int)Input.mouseScrollDelta.y;
                    PureLogger.Log($"Fly speed: {Vars.flySpeed}");
                }


                if (Input.GetKey(KeyCode.W))
                    player.transform.position += playercamera.transform.forward * Vars.flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.A))
                    player.transform.position -= playercamera.transform.right * Vars.flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.S))
                    player.transform.position -= playercamera.transform.forward * Vars.flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.D))
                    player.transform.position += playercamera.transform.right * Vars.flySpeed * Time.deltaTime;

                if (Input.GetKey(KeyCode.E))
                    player.transform.position += playercamera.transform.up * Vars.flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.Q))
                    player.transform.position -= playercamera.transform.up * Vars.flySpeed * Time.deltaTime;

                if (System.Math.Abs(Input.GetAxis("Joy1 Axis 2")) > 0f)
                    player.transform.position += playercamera.transform.forward * Vars.flySpeed * Time.deltaTime * (Input.GetAxis("Joy1 Axis 2") * -1f);
                if (System.Math.Abs(Input.GetAxis("Joy1 Axis 1")) > 0f)
                    player.transform.position += playercamera.transform.right * Vars.flySpeed * Time.deltaTime * Input.GetAxis("Joy1 Axis 1");
            }
        }
    }
}