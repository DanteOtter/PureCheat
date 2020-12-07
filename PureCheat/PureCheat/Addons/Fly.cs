using System;
using UnityEngine;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class Fly : PureModSystem
    {
        public override string ModName => "Fly";

        public static int flySpeed = 2;
        public static bool isFly = false;

        public static QMNestedButton flyMenu;
        public static QMToggleButton toggleFlyButton;
        public static QMSingleButton resetFlySpeedButton;

        public override void OnStart()
        {
            flyMenu = new QMNestedButton(QMUI.UIMenuP1, 1, 0, "Fly\nMenu", "Fly Menu");

            toggleFlyButton = new QMToggleButton(flyMenu, 1, 0, "Fly ON", new Action(() =>
            {
                isFly = true;
                PureUtils.GetLocalPlayer().GetComponent<CharacterController>().enabled = false;
            }), "Fly OFF", new Action(() =>
            {
                isFly = false;
                PureUtils.GetLocalPlayer().GetComponent<CharacterController>().enabled = true;
            }), "Toggle fly");

            resetFlySpeedButton = new QMSingleButton(flyMenu, 2, 0, $"Reset\nSpeed\n[{flySpeed}]", new Action(() =>
            {
                flySpeed = 2;
                resetFlySpeedButton.setButtonText($"Reset\nSpeed\n[{flySpeed}]");
            }), "Reset fly speed");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isFly = !isFly;
                if (isFly)
                {
                    PureUtils.GetLocalPlayer().GetComponent<CharacterController>().enabled = false;
                    PureLogger.Log("Fly enabled");
                }
                else
                {
                    PureUtils.GetLocalPlayer().GetComponent<CharacterController>().enabled = true;
                    PureLogger.Log("Fly disabled");
                }
                toggleFlyButton.setToggleState(isFly);
            }

            if (isFly)
            {
                GameObject player = PureUtils.GetLocalPlayer();
                GameObject playerCamera = PureUtils.GetLocalPlayerCamera();

                if (Input.mouseScrollDelta.y != 0)
                {
                    flySpeed += (int)Input.mouseScrollDelta.y;

                    if (flySpeed <= 0)
                        flySpeed = 1;

                    resetFlySpeedButton.setButtonText($"Reset\nSpeed\n[{flySpeed}]");
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