using UnityEngine;
using PureCheat.API;

namespace PureCheat.Addons
{
    public class UnlimitedAvatarFavorite : PureModSystem
    {
        public override string ModName => "Unlimited avatar favorite";

        GameObject favButton;

        public override void OnStart() =>
            favButton = GameObject.Find("/UserInterface/MenuContent/Screens/Avatar/Change Button");


        public override void OnLateUpdate()
        {
            favButton.SetActive(true);
        }
    }
}
