using UnityEngine;
using VRC.SDKBase;
using PureCheat.API;
using PlagueButtonAPI;

namespace PureCheat.Addons
{
    public class OptimizeMirrors : PureModSystem
    {
        public override string ModName => "Optimize mirrors";

        public override void OnStart()
        {
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "Mirror", "Toggle mirror quality" ,
                ButtonAPI.HorizontalPosition.FourthButtonPos, ButtonAPI.VerticalPosition.SecondButton, ButtonAPI.MakeEmptyPage("PureCheat").transform, delegate (bool a)
                {
                    MirrorReflection[] array = Object.FindObjectsOfType<MirrorReflection>();
                    LayerMask mask = new LayerMask();

                    mask.value = a ? 263680 : -1025;

                    for (int i = 0; i < array.Length; i++)
                        array[i].m_ReflectLayers = mask;

                    VRCSDK2.VRC_MirrorReflection[] array2 = Object.FindObjectsOfType<VRCSDK2.VRC_MirrorReflection>();
                    for (int i = 0; i < array2.Length; i++)
                        array2[i].m_ReflectLayers = mask;

                    VRC_MirrorReflection[] array4 = Object.FindObjectsOfType<VRC_MirrorReflection>();
                    for (int i = 0; i < array4.Length; i++)
                        array4[i].m_ReflectLayers = mask;

                }, Color.white, Color.green, null, false, false);
        }
    }
}
