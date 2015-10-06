using System;
using UnityEditor;
using UnityEngine;
using HattoriGame2.Core;
using HattoriGame2.Core.Components;
using GUID = HattoriGame2.Core.GUID;

namespace HattoriGame2.Editor
{
    [CustomEditor(typeof(GUIDComponent))]
    public class GUIDComponentEditor : UnityEditor.Editor
    {
        private GUIDComponent targetGUIDComponent;
        private bool PrintUppercase = true;
        private string PrintDelimeter = " - ";
        private bool PrintWithBraces = true;

        public void OnEnable()
        {
            targetGUIDComponent = target as GUIDComponent;
            PrintUppercase = EditorPrefs.GetBool("GUIDComponent_PrintUppercase", true);
            PrintDelimeter = EditorPrefs.GetString("GUIDComponent_PrintDelimeter", " - ");
            PrintWithBraces = EditorPrefs.GetBool("GUIDComponent_PrintBraces", true);
        }

        public void SetUppercaseOn()
        {
            PrintUppercase = true;
            EditorPrefs.SetBool("GUIDComponent_PrintUppercase", true);
        }

        public void SetUppercaseOff()
        {
            PrintUppercase = false;
            EditorPrefs.SetBool("GUIDComponent_PrintUppercase", false);
        }

        public void SetDelimeterEmpty()
        {
            PrintDelimeter = null;
            EditorPrefs.SetString("GUIDComponent_PrintDelimeter", null);
        }
        public void SetDelimeterStandart()
        {
            PrintDelimeter = " - ";
            EditorPrefs.SetString("GUIDComponent_PrintDelimeter", " - ");
        }

        public void SetDelimeterCondensed()
        {
            PrintDelimeter = "-";
            EditorPrefs.SetString("GUIDComponent_PrintDelimeter", "-");
        }

        public void SetBracesOn()
        {
            PrintWithBraces = true;
            EditorPrefs.SetBool("GUIDComponent_PrintBraces", true);
        }

        public void SetBracesOff()
        {
            PrintWithBraces = false;
            EditorPrefs.SetBool("GUIDComponent_PrintBraces", false);
        }

        public void Generate()
        {
            targetGUIDComponent.GUID = GUID.Generate();
        }

        public void Copy()
        {
            EditorGUIUtility.systemCopyBuffer = targetGUIDComponent.GUID.ToString(PrintUppercase, PrintDelimeter, PrintWithBraces);
        }

        public void Paste()
        {
            targetGUIDComponent.GUID = new GUID(EditorGUIUtility.systemCopyBuffer);
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();

                GUI.skin.label.alignment = TextAnchor.MiddleCenter;
                GUILayout.Label(targetGUIDComponent.GUID.ToString(PrintUppercase, PrintDelimeter, PrintWithBraces));
                GUI.skin.label.alignment = TextAnchor.MiddleLeft;

                GUILayout.FlexibleSpace();

                if (GUILayout.Button("..."))
                {
                    var menu = new GenericMenu();
                    menu.AddItem(new GUIContent("Generate"), false, Generate);
                    menu.AddItem(new GUIContent("Clipboard/Copy"), false, Copy);
                    menu.AddItem(new GUIContent("Clipboard/Paste"), false, Paste);
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent("Customize/Uppercase/On"), PrintUppercase, SetUppercaseOn);
                    menu.AddItem(new GUIContent("Customize/Uppercase/Off"), !PrintUppercase, SetUppercaseOff);
                    menu.AddItem(new GUIContent("Customize/Delimeter/Empty"), String.IsNullOrEmpty(PrintDelimeter), SetDelimeterEmpty);
                    menu.AddItem(new GUIContent("Customize/Delimeter/Standart"), PrintDelimeter == " - ", SetDelimeterStandart);
                    menu.AddItem(new GUIContent("Customize/Delimeter/Condensed"), PrintDelimeter == "-", SetDelimeterCondensed);
                    menu.AddItem(new GUIContent("Customize/Braces/On"), PrintWithBraces, SetBracesOn);
                    menu.AddItem(new GUIContent("Customize/Braces/Off"), !PrintWithBraces, SetBracesOff);
                    menu.ShowAsContext();
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}