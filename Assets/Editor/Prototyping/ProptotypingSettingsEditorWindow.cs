using UnityEngine;
using UnityEditor;
using System;

namespace HattoriGame2.Prototyping
{
    public class PrototypingSettingsEditorWindow : EditorWindow
    {
        private const string WindowCaption = "Prototyping Settings";

        public static PrototypingSettingsEditorWindow Initialize()
        {
            return EditorWindow.GetWindow<PrototypingSettingsEditorWindow>(true, WindowCaption, true);
        }

        public void OnGUI()
        {

        }
    }
}