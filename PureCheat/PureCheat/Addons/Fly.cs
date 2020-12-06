using UnityEngine;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class Fly : PureModSystem
    {
        public override string ModName => "Fly";

        public static int flySpeed = 2;
        public static bool isFly = false;



        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isFly = !isFly;
                if (isFly)
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

            if (isFly)
            {
                GameObject player = PureUtils.GetLocalPlayer();
                GameObject playerCamera = PureUtils.GetLocalPlayerCamera();

                if (flySpeed <= 0)
                    flySpeed = 1;

                if (Input.mouseScrollDelta.y != 0)
                {
                    flySpeed += (int)Input.mouseScrollDelta.y;
                    PureLogger.Log($"Fly speed: {flySpeed}");
                }


                if (Input.GetKey(KeyCode.W))
                    player.transform.position += playerCamera.transform.forward * flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.A))
                    player.transform.position -= playerCamera.transform.right * flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.S))
                    player.transform.position -= playerCamera.transform.forward * flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.D))
                    player.transform.position += playerCamera.transform.right * flySpeed * Time.deltaTime;

                if (Input.GetKey(KeyCode.E))
                    player.transform.position += playerCamera.transform.up * flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.Q))
                    player.transform.position -= playerCamera.transform.up * flySpeed * Time.deltaTime;

                if (System.Math.Abs(Input.GetAxis("Joy1 Axis 2")) > 0f)
                    player.transform.position += playerCamera.transform.forward * flySpeed * Time.deltaTime * (Input.GetAxis("Joy1 Axis 2") * -1f);
                if (System.Math.Abs(Input.GetAxis("Joy1 Axis 1")) > 0f)
                    player.transform.position += playerCamera.transform.right * flySpeed * Time.deltaTime * Input.GetAxis("Joy1 Axis 1");
            }
        }
    }
}