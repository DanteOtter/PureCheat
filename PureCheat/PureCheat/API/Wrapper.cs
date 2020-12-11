using VRC;
using VRC.UI;
using System;
using VRC.Core;
using System.IO;
using System.Net;
using UnityEngine;
using System.Linq;
using UnhollowerBaseLib;
using System.Collections.Generic;

namespace PureCheat.API
{
    public enum TrustLevel
    {
        Visitor = 0,
        New = 1,
        User = 2,
        Known = 3,
        Trusted = 4,
        Veteran = 5,
        unknown = 99
    }

    public static class PlayerWrapper
    {
        public static List<string> friend_list = new List<string>();
        private static float last_friend_update = 0f;

        public static VRCPlayer GetCurrentPlayer()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0;
        }

        public static Il2CppSystem.Collections.Generic.List<Player> GetAllPlayers()
        {
            return Wrapper.GetPlayerManager().field_Private_List_1_Player_0;
        }

        public static APIUser GetAPIUser(this Player player)
        {
            return player.field_Private_APIUser_0;
        }

        public static string GetWorldID(Player p)
        {
            return p.field_Private_APIUser_0.worldId;
        }

        public static Player GetPlayer(string UserID)
        {
            Il2CppSystem.Collections.Generic.List<Player> Players = GetAllPlayers();
            Player Foundplayer = null;
            for (int i = 0; i < Players.Count; i++)
            {
                Player player = Players[i];
                if (player.GetAPIUser().id == UserID)
                {
                    Foundplayer = player;
                }
            }
            return Foundplayer;
        }

        public static void RemoveAvatar(Player user)
        {
            Il2CppArrayBase<MeshFilter> componentsInChildren = user.GetComponentsInChildren<MeshFilter>();
            foreach (MeshFilter meshFilter in componentsInChildren)
                UnityEngine.Object.Destroy(meshFilter);
        }

        public static void HideAvatar(Player user)
        {
            Il2CppArrayBase<MeshFilter> componentsInChildren = user.GetComponentsInChildren<MeshFilter>();
            foreach (MeshFilter meshFilter in componentsInChildren)
                meshFilter.gameObject.SetActive(false);

        }
        public static void ShowAvatar(Player user)
        {
            Il2CppArrayBase<MeshFilter> componentsInChildren = user.GetComponentsInChildren<MeshFilter>();
            foreach (MeshFilter meshFilter in componentsInChildren)
                meshFilter.gameObject.SetActive(true);
        }

        public static void UpdateFriendList()
        {
            if (Time.time > last_friend_update)
            {
                last_friend_update = Time.time + 10f;
                friend_list.Clear();
                for (int i = 0; i < APIUser.CurrentUser.friendIDs.Count; i++)
                {
                    string item = APIUser.CurrentUser.friendIDs[i];
                    friend_list.Add(item);
                }
            }
        }

        public static APIUser GetAPIUserFromSocialPage()
        {
            GameObject screens = GameObject.Find("Screens");
            APIUser ourSelectedPlayer = screens.transform.Find("UserInfo").transform.GetComponentInChildren<PageUserInfo>().user;
            return ourSelectedPlayer;
        }

        public static ulong GetSteamID(this VRCPlayer player)
        {
            return player.field_Private_UInt64_0;
        }

        public static bool isFriend(Player p)
        {
            return friend_list.Contains(p.field_Private_APIUser_0.id);
        }

        public static TrustLevel GetTrustLevel(Player p)
        {
            try
            {
                if (p.field_Private_APIUser_0.hasLegendTrustLevel)
                    return TrustLevel.Veteran; //"Veteran user";
                if (p.field_Private_APIUser_0.hasVeteranTrustLevel)
                    return TrustLevel.Trusted;//"Trusted user";
                if (p.field_Private_APIUser_0.hasTrustedTrustLevel)
                    return TrustLevel.Known; //"Known user";
                if (p.field_Private_APIUser_0.hasKnownTrustLevel)
                    return TrustLevel.User; //"User";
                if (p.field_Private_APIUser_0.hasBasicTrustLevel)
                    return TrustLevel.New; //"New user";
                if (p.field_Private_APIUser_0.isUntrusted)
                    return TrustLevel.Visitor; //"Visitor";
            }
            catch (Exception)
            {
                return TrustLevel.unknown;//"unknown";
            }
            return TrustLevel.unknown;//"unknown";
        }
    }

    public static class Wrapper
    {
        public static string[] shader_list;
        public static List<string> shader_list_local = new List<string>();
        public static List<string> friend_list = new List<string>();

        public static GameObject GetPlayerCamera()
        {
            return GameObject.Find("Camera (eye)");
        }

        public static ApiWorldInstance GetInstance()
        {
            return RoomManager.field_Internal_Static_ApiWorldInstance_0;
        }

        public static void EnableOutline(this HighlightsFX instance, Renderer renderer, bool state)
        {
            instance.Method_Public_Void_Renderer_Boolean_0(renderer, state); //First method to take renderer, bool parameters
        }

        public static HighlightsFX GetHighlightsFX()
        {
            return HighlightsFX.prop_HighlightsFX_0;
        }

        public static PlayerManager GetPlayerManager()
        {
            return PlayerManager.prop_PlayerManager_0;
        }

        public static QuickMenu GetQuickMenu()
        {
            return QuickMenu.prop_QuickMenu_0;
        }

        public static void SetToolTipBasedOnToggle(this UiTooltip tooltip)
        {
            UiToggleButton componentInChildren = tooltip.gameObject.GetComponentInChildren<UiToggleButton>();

            if (componentInChildren != null && !string.IsNullOrEmpty(tooltip.alternateText))
            {
                string displayText = (!componentInChildren.toggledOn) ? tooltip.alternateText : tooltip.text;
                if (TooltipManager.field_Private_Static_Text_0 != null) //Only return type field of text
                    TooltipManager.Method_Public_Static_Void_String_0(displayText); //Last function to take string parameter
                else if (tooltip != null)
                    tooltip.text = displayText;
            }
        }

        public static VRCUiManager GetVRCUiManager()
        {
            return VRCUiManager.prop_VRCUiManager_0;
        }

        public static Player GetSelectedPlayer(this QuickMenu instance)
        {
            APIUser apiUser = instance.field_Private_APIUser_0;
            return PlayerWrapper.GetPlayer(apiUser.id);
        }

        public static string[] to_array(WebResponse res)
        {
            return convert(res).Split(Environment.NewLine.ToCharArray());
        }

        public static bool is_known(string shader)
        {
            return (shader_list.Contains(shader)) || shader_list_local.Contains(shader);
        }

        public static string convert(WebResponse res)
        {
            string result = "";
            using (Stream responseStream = res.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(responseStream))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            res.Dispose();
            return result;
        }
    }
}
