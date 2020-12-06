using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PureCheat.API
{
    class PureUtils
    {
        public static GameObject[] GetAllGameObjects()
        {
            return SceneManager.GetActiveScene().GetRootGameObjects();
        }

        public static GameObject GetLocalPlayer()
        {
            foreach (GameObject gameObject in GetAllGameObjects())
                if (gameObject.name.StartsWith("VRCPlayer[Local]"))
                    return gameObject; // Success

            return new GameObject(); // Error
        }

        public static GameObject GetLocalPlayerCamera()
        {
            return GameObject.Find("Camera (eye)"); // Success
        }
    }
}
