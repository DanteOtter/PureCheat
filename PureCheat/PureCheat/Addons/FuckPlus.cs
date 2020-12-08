using UnityEngine;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class FuckPlus : PureModSystem
    {
        public override string ModName => "Fuck VRC+";

        public override void OnStart()
        {

            GameObject.Destroy(GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/UserIconTab"));
            GameObject.Destroy(GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/VRC+PageTab"));
            GameObject.Destroy(GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/User Panel/Supporter"));
            GameObject.Destroy(GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Favorite Avatar List/GetMoreFavorites"));

            foreach (GameObject gameObject in PureUtils.GetAllObjectsInSceneTree())
                if (gameObject.transform.name == "VRCPlusBanner" || gameObject.transform.name == "VRCPlusMiniBanner")
                    GameObject.Destroy(gameObject);
        }
    }
}
