using VRC;
using VRC.Core;
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

        public static ApiWorldInstance GetInstance()
        {
            return RoomManager.field_Internal_Static_ApiWorldInstance_0;
        }

        public static Player GetSelectedPlayerOrNull()
        {
            Player Foundplayer = null;

            foreach (GameObject playerObject in GetAllPlayers())
                if (playerObject.GetComponent<Player>().field_Private_APIUser_0.id == GameObject.Find("/UserInterface/QuickMenu/ShortcutMenu").transform.parent.GetComponent<QuickMenu>().field_Private_APIUser_0.id)
                    Foundplayer = playerObject.GetComponent<Player>();

            return Foundplayer;
        }

        public static GameObject GetLocalPlayerCamera()
        {
            return GameObject.Find("Camera (eye)"); // Success
        }

        public static PlayerManager GetPlayerManager()
        {
            return GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        }

        public static Il2CppSystem.Collections.Generic.List<Player> GetPlayers()
        {
            return GetPlayerManager().field_Private_List_1_Player_0;
        }

        public static List<VRCPlayer> GetVRCPlayers()
        {
            List<VRCPlayer> playerList = new List<VRCPlayer>();

            foreach (GameObject player in GetAllPlayers())
                playerList.Add(player.GetComponent<VRCPlayer>());

            return playerList;
        }
    }
}
