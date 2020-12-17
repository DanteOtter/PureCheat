

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace PlagueButtonAPI
{
    public class ButtonAPI
    {
#pragma warning disable 414

        #region Creditation And Disclaimer

        private static string Creditation =
        "Plague Button API" +
        "http://Krewella.co.uk/Discord" +
        "Copyright Reserved" +
        "Use-Only Licensed" +
        "https://github.com/OFWModz/PlagueButtonAPI" +
        "Removal Or Modification Of This String Breaches The License." +
        "This String Is To Be Preserved AS IS.";

        #endregion Creditation And Disclaimer

#pragma warning restore 414

        #region Public Variables

        internal static Transform ShortcutMenuTransform =>
            GameObject.Find("/UserInterface/QuickMenu/ShortcutMenu").transform;

        internal static QuickMenu QuickMenuObj =>
            ShortcutMenuTransform.parent.GetComponent<QuickMenu>();

        internal static Transform UserInteractMenuTransform =>
            GameObject.Find("/UserInterface/QuickMenu/UserInteractMenu").transform;

        internal static List<GameObject> ButtonsFromThisMod = new List<GameObject>();

        #endregion Public Variables

        #region Main Functions

        #region Button Creation

        /// <summary>
        /// Creates A Button With A Lot Of Customization And Returns The GameObject Of The Button Made. | Created By Plague | Discord Server: http://Krewella.co.uk/Discord
        ///     <para>
        ///     As You Type Arguments Within This Method You Will See What Each Argument Does Here.
        ///     </para>
        ///
        ///     <example>
        ///     Here Is An Example Of How To Use This:
        ///         <code>
        ///         ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "Toggle Pickups", "Toggles All Pickups In The Current Instance.", ButtonAPI.HorizontalPosition.FirstButtonPos,      ButtonAPI.VerticalPosition.TopButton, null, delegate (bool a)
        ///            {
        ///                //Do Something Here
        ///            }, Color.white, Color.magenta, null, false, false, true);
        ///         </code>
        ///     </example>
        /// </summary>
        /// <param name="ButtonType">
        /// The Type Of Button You Wish To Create.
        /// </param>
        /// <param name="Text">
        /// The Main Text In The Button
        /// </param>
        /// <param name="ToolTip">
        /// The Text That Appears At The Top Of The Menu When You Hover Over The Button.
        /// </param>
        /// <param name="X">
        /// The Horizontal Position Of The Button.
        /// </param>
        /// <param name="Y">
        /// The Vertical Position Of The Button.
        /// </param>
        /// <param name="Parent">
        /// The Transform Of The GameObject You Wish To Put Your Button In (You Can Set This As Just "null" For The Main ShortcutMenu).
        /// </param>
        /// <param name="ButtonListener">
        /// What You Want The Button To Do When You Click It - Must Be delegate(bool nameofboolhere) {  }.
        /// </param>
        /// <param name="ToggledOffTextColour">
        /// The Colour You Want The Main Text Of The Button You Defined Earlier To Change Into If This Button Is Toggled Off.
        /// </param>
        /// <param name="ToggledOnTextColour">
        /// The Colour You Want The Main Text Of The Button You Defined Earlier To Change Into If This Button Is Toggled On.
        /// </param>
        /// <param name="BorderColour">
        /// The Colour You Want The Border Of The Button To Be (You Can Set This As Just "null" For The Default Colour That The ShortcutMenu Currently Is!).
        /// </param>
        /// <param name="FullSizeButton">
        /// If You Want This Button To Be A Full Size Normal Button, Or Half Sized (False) - Default Is Half Sized.
        /// </param>
        /// <param name="BottomHalf">
        /// If You Want This Button To Be On The Bottom Half Of The VericalPosition You Chose Or The Top - Default Is Bottom Half.
        /// </param>
        /// <param name="HalfHorizontally">
        /// If You Want This Button To Have It's Size Cut In Half Horizontally.
        /// </param>
        /// <param name="CurrentToggleState">
        /// The Toggle State You Want The Button To Be On Creation.
        /// </param>
        /// <param name="SpriteForButton">
        /// The Image Sprite You Want To Apply To The Button.
        /// </param>
        /// <param name="ChangeColourOnClick">
        /// Only Set This To False If You Are Setting The Button's Text Colour In The ButtonListener - Or The Toggling Will Break!
        /// </param>
        internal static GameObject CreateButton(ButtonType ButtonType, string Text, string ToolTip, HorizontalPosition X,
            VerticalPosition Y, Transform Parent, Action<bool> ButtonListener, Color ToggledOffTextColour,
            Color ToggledOnTextColour, Color? BorderColour, bool FullSizeButton = false, bool BottomHalf = true,
            bool HalfHorizontally = false, bool CurrentToggleState = false, Sprite SpriteForButton = null,
            bool ChangeColourOnClick = true)
        {
            //Prevent Weird Bugs Due To A Invalid Parent - Set It To The Main QuickMenu
            if (Parent == null)
            {
                Parent = ShortcutMenuTransform;
            }

            //Get The Transform Of The Settings Button - Which We Are Going To Use As Our Template
            Transform transform = UnityEngine.Object
                .Instantiate(GameObject.Find("/UserInterface/QuickMenu").GetComponent<QuickMenu>().transform.Find("ShortcutMenu/SettingsButton").gameObject)
                .transform;

            //Button Position Calculation
            float num =
                (GameObject.Find("/UserInterface/QuickMenu").GetComponent<QuickMenu>().transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x -
                GameObject.Find("/UserInterface/QuickMenu").GetComponent<QuickMenu>().transform.Find("UserInteractMenu/BanButton").localPosition.x) / 3.9f;

            //Change Internal Names & Sanitize Them
            transform.name = "PlagueButton_" + Text.Replace(" ", "_".Replace(",", "_").Replace(":", "_"));
            transform.transform.name = "PlagueButton_" + Text.Replace(" ", "_".Replace(",", "_").Replace(":", "_"));

            //Define Position To Place This Button In The Parent, Appended To Later
            if (BottomHalf || FullSizeButton)
            {
                if (Parent == UserInteractMenuTransform)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + num * (float)X,
                        transform.localPosition.y + num * ((float)Y - 2.95f), transform.localPosition.z);
                }
                else
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + num * (float)X,
                        transform.localPosition.y + num * ((float)Y - 1.95f), transform.localPosition.z);
                }
            }
            else
            {
                if (Parent == UserInteractMenuTransform)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + num * (float)X,
                    transform.localPosition.y + num * ((float)Y - 2.45f), transform.localPosition.z);
                }
                else
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + num * (float)X,
                        transform.localPosition.y + num * ((float)Y - 1.45f), transform.localPosition.z);
                }
            }

            //Define Where To Put This Button
            transform.SetParent(Parent, worldPositionStays: false);

            //Set Text, Tooltip & Colours
            transform.GetComponentInChildren<Text>().supportRichText = true;
            transform.GetComponentInChildren<Text>().text = Text;
            transform.GetComponentInChildren<UiTooltip>().text = ToolTip;
            transform.GetComponentInChildren<UiTooltip>().alternateText = ToolTip;

            if (CurrentToggleState && ButtonType != ButtonAPI.ButtonType.Default)
            {
                transform.GetComponentInChildren<Text>().color = ToggledOnTextColour;
            }
            else
            {
                transform.GetComponentInChildren<Text>().color = ToggledOffTextColour;
            }

            //Set The Button's Border Colour
            if (BorderColour != null)
            {
                transform.GetComponentInChildren<Image>().color = (Color)BorderColour;
            }

            //Size Scaling & Repositioning
            if (!FullSizeButton)
            {
                transform.localPosition +=
                    new Vector3(0f, transform.GetComponent<RectTransform>().sizeDelta.y / 5f, 0f);
                transform.localPosition -=
                    new Vector3(0f, transform.GetComponent<RectTransform>().sizeDelta.y / 2f, 0f);
                transform.GetComponent<RectTransform>().sizeDelta = new Vector2(
                    transform.GetComponent<RectTransform>().sizeDelta.x,
                    transform.GetComponent<RectTransform>().sizeDelta.y / 2f);
            }
            else
            {
                transform.localPosition -= new Vector3(0f, 20f, 0f);
            }

            if (HalfHorizontally)
            {
                transform.GetComponent<RectTransform>().sizeDelta = new Vector2(
                    transform.GetComponent<RectTransform>().sizeDelta.x / 2f,
                    transform.GetComponent<RectTransform>().sizeDelta.y);
            }

            if (SpriteForButton != null)
            {
                transform.GetComponentInChildren<Image>().sprite = SpriteForButton;
            }

            //Remove Any Previous Events
            transform.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();

            //Listener Redirection - To Get Around AddListener Not Passing A State Bool Due To Being A onClick Event
            transform.GetComponent<Button>().onClick.AddListener(new Action(() =>
            {
                if (ButtonType == ButtonType.Toggle)
                {
                    ButtonListener?.Invoke(transform.GetComponentInChildren<Text>().color != ToggledOnTextColour);
                }
                else
                {
                    ButtonListener?.Invoke(true);
                }
            }));

            if (ButtonType == ButtonType.Toggle)
            {
                //Set The Text Colour To The Toggle State, ToggledOnTextColour Being Toggled On
                transform.GetComponent<Button>().onClick.AddListener(new Action(() =>
                {
                    if (transform.GetComponentInChildren<Text>().color == ToggledOnTextColour)
                    {
                        transform.GetComponentInChildren<Text>().color = ToggledOffTextColour;
                    }
                    else
                    {
                        transform.GetComponentInChildren<Text>().color = ToggledOnTextColour;
                    }
                }));
            }

            ButtonsFromThisMod.Add(transform.gameObject);

            //Return The GameObject For Handling It Elsewhere
            return transform.gameObject;
        }

        /// <summary>
        /// Creates A Button With A Lot Of Customization And Returns The GameObject Of The Button Made. | Created By Plague | Discord Server: http://Krewella.co.uk/Discord
        ///     <para>
        ///     As You Type Arguments Within This Method You Will See What Each Argument Does Here.
        ///     </para>
        ///
        ///     <example>
        ///     Here Is An Example Of How To Use This:
        ///         <code>
        ///         ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "Toggle Pickups", "Toggles All Pickups In The Current Instance.", ButtonAPI.HorizontalPosition.FirstButtonPos,      ButtonAPI.VerticalPosition.TopButton, null, delegate (bool a)
        ///            {
        ///                //Do Something Here
        ///            }, Color.white, Color.magenta, null, false, false, true);
        ///         </code>
        ///     </example>
        /// </summary>
        /// <param name="ButtonType">
        /// The Type Of Button You Wish To Create.
        /// </param>
        /// <param name="Text">
        /// The Main Text In The Button
        /// </param>
        /// <param name="ToolTip">
        /// The Text That Appears At The Top Of The Menu When You Hover Over The Button.
        /// </param>
        /// <param name="X">
        /// The Horizontal Position Of The Button.
        /// </param>
        /// <param name="Y">
        /// The Vertical Position Of The Button.
        /// </param>
        /// <param name="Parent">
        /// The Transform Of The GameObject You Wish To Put Your Button In (You Can Set This As Just "null" For The Main ShortcutMenu).
        /// </param>
        /// <param name="ButtonListener">
        /// What You Want The Button To Do When You Click It - Must Be delegate(bool nameofboolhere) {  }.
        /// </param>
        /// <param name="ToggledOffTextColour">
        /// The Colour You Want The Main Text Of The Button You Defined Earlier To Change Into If This Button Is Toggled Off.
        /// </param>
        /// <param name="ToggledOnTextColour">
        /// The Colour You Want The Main Text Of The Button You Defined Earlier To Change Into If This Button Is Toggled On.
        /// </param>
        /// <param name="BorderColour">
        /// The Colour You Want The Border Of The Button To Be (You Can Set This As Just "null" For The Default Colour That The ShortcutMenu Currently Is!).
        /// </param>
        /// <param name="FullSizeButton">
        /// If You Want This Button To Be A Full Size Normal Button, Or Half Sized (False) - Default Is Half Sized.
        /// </param>
        /// <param name="BottomHalf">
        /// If You Want This Button To Be On The Bottom Half Of The VericalPosition You Chose Or The Top - Default Is Bottom Half.
        /// </param>
        /// <param name="HalfHorizontally">
        /// If You Want This Button To Have It's Size Cut In Half Horizontally.
        /// </param>
        /// <param name="CurrentToggleState">
        /// The Toggle State You Want The Button To Be On Creation.
        /// </param>
        /// <param name="SpriteForButton">
        /// The Image Sprite You Want To Apply To The Button.
        /// </param>
        /// <param name="ChangeColourOnClick">
        /// Only Set This To False If You Are Setting The Button's Text Colour In The ButtonListener - Or The Toggling Will Break!
        /// </param>
        internal static GameObject CreateButton(ButtonType ButtonType, string Text, string ToolTip, float X, float Y,
            Transform Parent, Action<bool> ButtonListener, Color ToggledOffTextColour, Color ToggledOnTextColour,
            Color? BorderColour, bool FullSizeButton = false, bool BottomHalf = true, bool HalfHorizontally = false,
            bool CurrentToggleState = false, Sprite SpriteForButton = null, bool ChangeColourOnClick = true)
        {
            //Prevent Weird Bugs Due To A Invalid Parent - Set It To The Main QuickMenu
            if (Parent == null)
            {
                Parent = ShortcutMenuTransform;
            }

            //Get The Transform Of The Settings Button - Which We Are Going To Use As Our Template
            Transform transform = UnityEngine.Object
                .Instantiate(GameObject.Find("/UserInterface/QuickMenu").GetComponent<QuickMenu>().transform.Find("ShortcutMenu/SettingsButton").gameObject)
                .transform;

            //Button Position Calculation
            float num =
                (GameObject.Find("/UserInterface/QuickMenu").GetComponent<QuickMenu>().transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x -
                GameObject.Find("/UserInterface/QuickMenu").GetComponent<QuickMenu>().transform.Find("UserInteractMenu/BanButton").localPosition.x) / 3.9f;

            //Change Internal Names & Sanitize Them
            transform.name = "PlagueButton_" + Text.Replace(" ", "_".Replace(",", "_").Replace(":", "_"));
            transform.transform.name = "PlagueButton_" + Text.Replace(" ", "_".Replace(",", "_").Replace(":", "_"));

            //Define Position To Place This Button In The Parent, Appended To Later
            if (BottomHalf || FullSizeButton)
            {
                if (Parent == UserInteractMenuTransform)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + num * (float)X,
                        transform.localPosition.y + num * ((float)Y - 2.95f), transform.localPosition.z);
                }
                else
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + num * (float)X,
                        transform.localPosition.y + num * ((float)Y - 1.95f), transform.localPosition.z);
                }
            }
            else
            {
                if (Parent == UserInteractMenuTransform)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + num * (float)X,
                        transform.localPosition.y + num * ((float)Y - 2.45f), transform.localPosition.z);
                }
                else
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + num * (float)X,
                        transform.localPosition.y + num * ((float)Y - 1.45f), transform.localPosition.z);
                }
            }

            //Define Where To Put This Button
            transform.SetParent(Parent, worldPositionStays: false);

            //Set Text, Tooltip & Colours
            transform.GetComponentInChildren<Text>().supportRichText = true;
            transform.GetComponentInChildren<Text>().text = Text;
            transform.GetComponentInChildren<UiTooltip>().text = ToolTip;
            transform.GetComponentInChildren<UiTooltip>().alternateText = ToolTip;

            if (CurrentToggleState && ButtonType != ButtonAPI.ButtonType.Default)
            {
                transform.GetComponentInChildren<Text>().color = ToggledOnTextColour;
            }
            else
            {
                transform.GetComponentInChildren<Text>().color = ToggledOffTextColour;
            }

            //Set The Button's Border Colour
            if (BorderColour != null)
            {
                transform.GetComponentInChildren<Image>().color = (Color)BorderColour;
            }

            //Size Scaling & Repositioning
            if (!FullSizeButton)
            {
                transform.localPosition +=
                    new Vector3(0f, transform.GetComponent<RectTransform>().sizeDelta.y / 5f, 0f);
                transform.localPosition -=
                    new Vector3(0f, transform.GetComponent<RectTransform>().sizeDelta.y / 2f, 0f);
                transform.GetComponent<RectTransform>().sizeDelta = new Vector2(
                    transform.GetComponent<RectTransform>().sizeDelta.x,
                    transform.GetComponent<RectTransform>().sizeDelta.y / 2f);
            }
            else
            {
                transform.localPosition -= new Vector3(0f, 20f, 0f);
            }

            if (HalfHorizontally)
            {
                transform.GetComponent<RectTransform>().sizeDelta = new Vector2(
                    transform.GetComponent<RectTransform>().sizeDelta.x / 2f,
                    transform.GetComponent<RectTransform>().sizeDelta.y);
            }

            if (SpriteForButton != null)
            {
                transform.GetComponentInChildren<Image>().sprite = SpriteForButton;
            }

            //Remove Any Previous Events
            transform.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();

            //Listener Redirection - To Get Around AddListener Not Passing A State Bool Due To Being A onClick Event
            transform.GetComponent<Button>().onClick.AddListener(new Action(() =>
            {
                if (ButtonType == ButtonType.Toggle)
                {
                    ButtonListener?.Invoke(transform.GetComponentInChildren<Text>().color != ToggledOnTextColour);
                }
                else
                {
                    ButtonListener?.Invoke(true);
                }
            }));

            if (ButtonType == ButtonType.Toggle)
            {
                //Set The Text Colour To The Toggle State, ToggledOnTextColour Being Toggled On
                transform.GetComponent<Button>().onClick.AddListener(new Action(() =>
                {
                    if (transform.GetComponentInChildren<Text>().color == ToggledOnTextColour)
                    {
                        transform.GetComponentInChildren<Text>().color = ToggledOffTextColour;
                    }
                    else
                    {
                        transform.GetComponentInChildren<Text>().color = ToggledOnTextColour;
                    }
                }));
            }

            ButtonsFromThisMod.Add(transform.gameObject);

            //Return The GameObject For Handling It Elsewhere
            return transform.gameObject;
        }

        #endregion Button Creation

        #region Sub Menu Creation And Handling

        /// <summary>
        /// Creates A Empty Page For Adding Buttons To, If The Page Already Exists, This Will Return It. | Created By Plague | Discord Server: http://Krewella.co.uk/Discord
        /// </summary>
        /// <param name="name">
        /// The Name You Want To Give The Page/Find Internally.
        /// </param>
        internal static GameObject MakeEmptyPage(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                PureCheat.API.PureLogger.Log(ConsoleColor.Red, "Your Empty Page Name Cannot Be Empty!");
                return null;
            }

            //If This Page Already Exists, Return It
            for (int i = 0; i < SubMenus.Count; i++)
            {
                GameObject menu = SubMenus[i];
                if (menu.name == "PlagueButtonAPI_" + name)
                {
                    return menu;
                }
            }

            //Clone The ShortcutMenu
            Transform transform = UnityEngine.Object.Instantiate(ShortcutMenuTransform.gameObject).transform;

            //Change Internal Names
            transform.transform.name = "PlagueButtonAPI_" + name;
            transform.name = "PlagueButtonAPI_" + name;

            //Remove All Buttons
            for (int i = 0; i < transform.childCount; i++)
            {
                UnityEngine.Object.Destroy(transform.GetChild(i).gameObject);
            }

            //Make This Page We Cloned A Child Of The QuickMenu
            transform.SetParent(GameObject.Find("/UserInterface/QuickMenu").GetComponent<QuickMenu>().transform, worldPositionStays: false);

            //Make This Page We Cloned Inactive By Default
            transform.gameObject.SetActive(value: false);

            //Add It To The Handler
            SubMenus.Add(transform.gameObject);

            //Return The GameObject For Handling It Elsewhere
            return transform.gameObject;
        }

        /// <summary>
        /// Sets A Button To Be Interactable Or Not. | Created By Plague | Discord Server: http://Krewella.co.uk/Discord
        /// </summary>
        /// <param name="button">
        /// The GameObject Of The Button To Set The Interactivity Of.
        /// </param>
        /// <param name="state">
        /// If You Want The Button To Be Interactable.
        /// </param>
        internal static void SetButtonInteractivity(GameObject button, bool state)
        {
            button.transform.GetComponent<Button>().interactable = state;
        }

        /// <summary>
        /// Returns The Sprite Of A Given Button's GameObject. | Created By Plague | Discord Server: http://Krewella.co.uk/Discord
        /// </summary>
        /// <param name="button">
        /// The GameObject Of The Button To Pull The Sprite From.
        /// </param>
        internal static Sprite GetSpriteFromButton(GameObject button)
        {
            return button.transform.GetComponentInChildren<Image>().sprite;
        }

        /// <summary>
        /// Finds A SubMenu Inside Said Transform Created By My Button API. This Method Will Not Create One Under This Name If Not Found. | Created By Plague | Discord Server: http://Krewella.co.uk/Discord
        /// </summary>
        /// <param name="name">
        /// The Name OF The SubMenu To Find.
        /// </param>
        /// <param name="WhereTheSubMenuIsInside">
        /// Where You Placed The SubMenu, Such As The ShortcutMenu Or UserInteractMenu.
        /// </param>
        internal static GameObject FindSubMenu(string name, Transform WhereTheSubMenuIsInside)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                PureCheat.API.PureLogger.Log(ConsoleColor.Red, "Your SubMenu Name Cannot Be Empty!");
                return null;
            }

            //Find The SubMenu And Return It
            return WhereTheSubMenuIsInside.Find("PlagueButtonAPI_" + name).gameObject;
        }

        /// <summary>
        /// Enters The Submenu. | Created By Plague | Discord Server: http://Krewella.co.uk/Discord
        /// </summary>
        /// <param name="name">
        /// The GameObject Of The SubMenu You Want To Enter.
        /// </param>
        internal static void EnterSubMenu(GameObject menu)
        {
            if (ShortcutMenuTransform.gameObject.active)
            {
                ShortcutMenuTransform.gameObject.SetActive(false);
            }

            if (UserInteractMenuTransform.gameObject.active)
            {
                UserInteractMenuTransform.gameObject.SetActive(false);
            }

            for (int i = 0; i < SubMenus.Count; i++)
            {
                GameObject Menu = SubMenus[i];
                Menu.SetActive(false);
            }

            if (menu != null)
            {
                menu.SetActive(true);
            }
        }

        /// <summary>
        /// Closes All SubMenus Created
        /// </summary>
        internal static void CloseAllSubMenus()
        {
            ShortcutMenuTransform.gameObject.SetActive(false);
            UserInteractMenuTransform.gameObject.SetActive(false);

            for (int i = 0; i < SubMenus.Count; i++)
            {
                GameObject Menu = SubMenus[i];
                Menu.SetActive(false);
            }
        }

        /// <summary>
        /// Sets The Buttons Toggle State. | Created By Plague | Discord Server: http://Krewella.co.uk/Discord
        /// </summary>
        /// <param name="button">
        /// The GameObject Of The Button You Wish To Set The Toggle State Of.
        /// </param>
        /// <param name="OffColour">
        /// The Off Colour You Chose For When The Button Is Toggled On Before.
        /// </param>
        /// <param name="OnColour">
        /// The On Colour You Chose For When The Button Is Toggled On Before.
        /// </param>
        /// <param name="StateToSetTo">
        /// The Toggle State You Wish To Set This Button To.
        /// </param>
        internal static void SetToggleState(GameObject button, Color OffColour, Color OnColour, bool StateToSetTo)
        {
            if (button != null)
            {
                if (button.GetComponentInChildren<Text>().color == OnColour)
                {
                    button.GetComponentInChildren<Text>().color = OffColour;
                }
                else
                {
                    button.GetComponentInChildren<Text>().color = OnColour;
                }
            }
        }

        #endregion Sub Menu Creation And Handling

        #endregion Main Functions

        #region Internal Enumerations

        /// <summary>
        /// The Horizontal Position Of The Button You Are Creating.
        /// </summary>
        internal enum HorizontalPosition
        {
            TwoLeftOfMenu = -5,

            LeftOfMenu = -4,

            FirstButtonPos = -3,

            SecondButtonPos = -2,

            ThirdButtonPos = -1,

            FourthButtonPos = 0,

            RightOfMenu = 1
        }

        /// <summary>
        /// The Vertical Position Of The Button You Are Creating.
        /// </summary>
        internal enum VerticalPosition
        {
            TwoAboveMenu = 6,

            AboveMenu = 5,

            AboveTopButton = 4,

            TopButton = 3,

            SecondButton = 2,

            BottomButton = 1,

            BelowBottomButton = 0
        }

        /// <summary>
        /// The Type Of Button You Are Creating.
        /// </summary>
        internal enum ButtonType
        {
            Default,
            Toggle
        }

        #endregion Internal Enumerations

        #region Internal Functions - Not For The End User

        //Any Created Sub Menus By The User Are Stored Here
        private static List<GameObject> SubMenus = new List<GameObject>();

        internal static void SubMenuHandler()
        {
            if (SubMenus != null && SubMenus.Count > 0)
            {
                //If User Has Loaded A World
                if (RoomManager.prop_Boolean_3)
                {
                    //Vital Null Check
                    if (VRCPlayer.field_Internal_Static_VRCPlayer_0 != null)
                    {
                        if (QuickMenuObj != null)
                        {
                            for (int i = 0; i < SubMenus.Count; i++)
                            {
                                GameObject Menu = SubMenus[i];

                                if (Menu.active) // Is In This SubMenu
                                {
                                    //If QuickMenu Was Closed
                                    if (!QuickMenuObj.prop_Boolean_0)
                                    {
                                        //Hide SubMenu
                                        Menu.SetActive(false);
                                    }

                                    //If QuickMenu Is Open Normally When In A SubMenu (Aka When It Shouldn't Be)
                                    else if (QuickMenuObj.prop_Boolean_0 && (ShortcutMenuTransform.gameObject.active || UserInteractMenuTransform.gameObject.active))
                                    {
                                        ShortcutMenuTransform.gameObject.SetActive(false);
                                        UserInteractMenuTransform.gameObject.SetActive(false);
                                    }

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion Internal Functions - Not For The End User
    }
}
