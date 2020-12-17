using System;
using UnityEngine;
using PureCheat.API;
using UnityEngine.UI;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class Fly : PureModSystem
    {
        public override string ModName => "Fly";

        public static int flySpeed = 2;
        public static bool isFly = false;

        public static GameObject toggleFlyButton = null;
        public static GameObject resetFlySpeedButton = null;

        public override void OnStart()
        {
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Fly Menu", "Fly menu",
                ButtonAPI.HorizontalPosition.FirstButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    ButtonAPI.EnterSubMenu(ButtonAPI.MakeEmptyPage("FlyMenu"));
                }, Color.white, Color.white, null, false, false);

            toggleFlyButton = ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "Fly", "Toggle fly",
                ButtonAPI.HorizontalPosition.FirstButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("FlyMenu").transform, delegate (bool a)
                {
                    isFly = a;
                    PureUtils.GetLocalPlayer().GetComponent<CharacterController>().enabled = !a;
                    PureLogger.Log(a ? "Fly enabled" : "Fly Disabled");
                }, Color.white, Color.red, null, false, false);

            resetFlySpeedButton = ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, $"Speed [{flySpeed}]", "Reset fly speed",
                ButtonAPI.HorizontalPosition.FirstButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("FlyMenu").transform, delegate (bool a)
                {
                    flySpeed = 2;
                    resetFlySpeedButton.transform.GetComponentInChildren<Text>().text = $"Speed [{flySpeed}]";
                }, Color.white, Color.white, null, false);

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "▲", "Fly speed up",
                ButtonAPI.HorizontalPosition.SecondButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("FlyMenu").transform, delegate (bool a)
                {
                    flySpeed += 1;
                    resetFlySpeedButton.transform.GetComponentInChildren<Text>().text = $"Speed [{flySpeed}]";
                }, Color.white, Color.white, null, false, false);

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "▼", "Fly speed down",
                ButtonAPI.HorizontalPosition.SecondButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("FlyMenu").transform, delegate (bool a)
                {
                    flySpeed -= 1;

                    if (flySpeed <= 0)
                        flySpeed = 1;

                    resetFlySpeedButton.transform.GetComponentInChildren<Text>().text = $"Speed [{flySpeed}]";
                }, Color.white, Color.white, null, false);
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
                toggleFlyButton.GetComponent<Button>().onClick.Invoke();

            if (isFly)
            {
                GameObject player = PureUtils.GetLocalPlayer();
                GameObject playerCamera = PureUtils.GetLocalPlayerCamera();

                if (Input.mouseScrollDelta.y != 0)
                {
                    flySpeed += (int)Input.mouseScrollDelta.y;

                    if (flySpeed <= 0)
                        flySpeed = 1;
                    resetFlySpeedButton.transform.GetComponentInChildren<Text>().text = $"Speed [{flySpeed}]";
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

                if (Math.Abs(Input.GetAxis("Joy1 Axis 2")) > 0f)
                    player.transform.position += playerCamera.transform.forward * flySpeed * Time.deltaTime * (Input.GetAxis("Joy1 Axis 2") * -1f);
                if (Math.Abs(Input.GetAxis("Joy1 Axis 1")) > 0f)
                    player.transform.position += playerCamera.transform.right * flySpeed * Time.deltaTime * Input.GetAxis("Joy1 Axis 1");
            }
        }
    }
}