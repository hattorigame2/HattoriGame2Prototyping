using System;
using UnityEngine;

namespace HattoriGame2.Core.Components
{
    [RequireComponent(typeof(GameObjectLifetimeComponent))]
    [AddComponentMenu("Hattori Game 2/Core/GUID")]
    [DisallowMultipleComponent]
    [HelpURL("http://hattorigame2.github.io/HattoriGame2Prototyping/Docs/html/class_hattori_game2_1_1_core_1_1_components_1_1_g_u_i_d_component.html")]
    public class GUIDComponent : MonoBehaviour
    {
        [SerializeField]
        public GUID GUID;
    }
}
