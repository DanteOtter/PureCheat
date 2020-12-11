using System;
using UnityEngine;
using PureCheat.API;
using RubyButtonAPI;

namespace PureCheat.Addons
{
    public class FOVChanger : PureModSystem
    {
        public override string ModName => "Field of view changer";

        private float defaultFOV;
        public float FOV = 66;

        private Camera playerCamera;

        public static QMNestedButton fovMenu;
        public static QMSingleButton resetFOVButton;
        public static QMHalfButton fovUp;
        public static QMHalfButton fovDown;

        public override void OnStart()
        {
            playerCamera = PureUtils.GetLocalPlayerCamera().GetComponent<Camera>();

            defaultFOV = playerCamera.fieldOfView;
            playerCamera.fieldOfView = FOV;

            fovMenu = new QMNestedButton(QMUI.UIMenuP1, 1, 1, "FOV\nMenu", "Field of view menu");

            resetFOVButton = new QMSingleButton(fovMenu, 1, 0, $"Reset\nFOV\n[{FOV}]", new Action(() =>
            {
                FOV = defaultFOV;
                playerCamera.fieldOfView = FOV;
                resetFOVButton.setButtonText($"Reset\nFOV\n[{FOV}]");
            }), $"Set field of view to {defaultFOV}");

            fovUp = new QMHalfButton(fovMenu, 2, 0.0f, "▲", new Action(() =>
            {
                FOV += 1.0f;
                playerCamera.fieldOfView = FOV;
                resetFOVButton.setButtonText($"Reset\nFOV\n[{FOV}]");
            }), "Set field of view up");

            fovDown = new QMHalfButton(fovMenu, 2, 0.5f, "▼", new Action(() =>
            {
                FOV -= 1.0f;
                playerCamera.fieldOfView = FOV;
                resetFOVButton.setButtonText($"Reset\nFOV\n[{FOV}]");
            }), "Set field of view down");
        }
    }
}
