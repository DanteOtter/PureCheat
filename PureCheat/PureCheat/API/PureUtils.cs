using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace PureCheat.API
{
    public class PureUtils
    {
        public static GameObject[] GetAllGameObjects()
        {
            return SceneManager.GetActiveScene().GetRootGameObjects();
        }

        public static List<GameObject> GetAllPlayers()
        {
            List<GameObject> playerList = new List<GameObject>();

            foreach (GameObject gameObject in PureUtils.GetAllGameObjects())
                if (gameObject.name.StartsWith("VRCPlayer"))
                    playerList.Add(gameObject);

            return playerList; // Success
        }

        public static List<GameObject> GetAllObjectsInSceneTree()
        {
            List<GameObject> objectsInScene = new List<GameObject>();

            foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>())
                objectsInScene.Add(go);

            return objectsInScene; // Success
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
