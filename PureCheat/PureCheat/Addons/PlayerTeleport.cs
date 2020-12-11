using VRC;
using System;
using UnityEngine;
using RubyButtonAPI;
using PureCheat.API;
using System.Collections.Generic;

namespace PureCheat.Addons
{
    public class PlayerTeleport : PureModSystem
    {
        public override string ModName => "Teleport to player";

        public static QMNestedButton teleportMenu;
        private static List<QMHalfButton> playerButtons = new List<QMHalfButton>();

        public override void OnStart()
        {
            teleportMenu = new QMNestedButton(QMUI.UIMenuP1, 2, 0, "Teleport\nMenu", new Action(() =>
            {
                PlayerWrapper.UpdateFriendList();
                
                foreach (QMHalfButton button in playerButtons)
                    button.DestroyMe();

                playerButtons.Clear();

                int localButtonXPosition = 1;
                float localButtonYPosition = 0.0f;

                foreach (Player player in PlayerWrapper.GetAllPlayers())
                {
                    QMHalfButton tmpButton = new QMHalfButton(teleportMenu, localButtonXPosition, localButtonYPosition, player.ToString(), new Action(() =>
                    {
                        if (player != null)
                            PureUtils.GetLocalPlayer().transform.position = player.transform.position;
                        else
                            PureLogger.Log(ConsoleColor.Red, "Target is missing!");
                    }), $"Teleport to {player.ToString()}");

                    #region colorize

                    if (PlayerWrapper.isFriend(player))
                        tmpButton.setTextColor(Color.yellow);
                    else
                        tmpButton.setTextColor(Color.white);

                    if (PlayerWrapper.GetTrustLevel(player) == TrustLevel.Veteran)
                        tmpButton.setBackgroundColor(Color.red);
                    else if (PlayerWrapper.GetTrustLevel(player) == TrustLevel.Trusted)
                        tmpButton.setBackgroundColor(Color.magenta);
                    else if (PlayerWrapper.GetTrustLevel(player) == TrustLevel.Known)
                        tmpButton.setBackgroundColor(Color.Lerp(Color.yellow, Color.red, 0.5f));
                    else if (PlayerWrapper.GetTrustLevel(player) == TrustLevel.User)
                        tmpButton.setBackgroundColor(Color.green);
                    else if (PlayerWrapper.GetTrustLevel(player) == TrustLevel.New)
                        tmpButton.setBackgroundColor(new Color(0.19f, 0.45f, 0.62f));
                    else if (PlayerWrapper.GetTrustLevel(player) == TrustLevel.Visitor)
                        tmpButton.setBackgroundColor(Color.gray);

                    #endregion

                    localButtonXPosition++;
                    if (localButtonXPosition > 4)
                    {
                        if (localButtonXPosition == 4 && localButtonYPosition == 2.5f)
                            localButtonXPosition = 0;
                        else
                            localButtonXPosition = 1;

                        localButtonYPosition += 0.5f;
                    }
                    playerButtons.Add(tmpButton);
                }

            }), "Teleport To Player");
        }
    }
}
