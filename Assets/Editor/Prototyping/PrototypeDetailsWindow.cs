using UnityEngine;
using UnityEditor;
using System;
using HattoriGame2.Editor;

namespace HattoriGame2.Prototyping.Editor
{
    public class PrototypeDetailsWindow : EditorWindow
    {
        private enum Tab : int
        {
            Description = 0,
            Keys = 1,
            Objects = 2,
            Fields = 3,
            Relations = 4            
        }

        private static readonly GUIContent[] TabsContent = new GUIContent[] 
        {
            new GUIContent("Description"),
            new GUIContent("Keys"),
            new GUIContent("Objects"),
            new GUIContent("Fields"),
            new GUIContent("Relations")
        };

        private const string WindowCaption = "Prototype Details";

        private static readonly GUIContent NameLabelContent = new GUIContent("Name");
        private static readonly GUIContent DescriptionLabelContent = new GUIContent("Description");
        private static readonly GUIContent IsEnabledContent = new GUIContent("Is Enabled");

        public static readonly GUIContent DefaultAcceptButtonContent = new GUIContent("Accept");
        public static readonly GUIContent DefaultCancelButtonContent = new GUIContent("Cancel");

        private const float NormalSpace = 10f;
        private const float SmallSpace = 5f;
        private const float LabelWidth = 100f;
        private const float DescriptionAreaHeight = 100f;

        private static readonly Vector4 WindowContentPadding = new Vector4(NormalSpace, NormalSpace, NormalSpace, NormalSpace);
        private static readonly Vector4 TabToolbarPadding = new Vector4(SmallSpace, SmallSpace, SmallSpace, SmallSpace);
        private static readonly Vector4 TabContentPadding = new Vector4(SmallSpace, SmallSpace, SmallSpace, SmallSpace);

        public PrototypeData PrototypeData { get; private set; }

        public GUIContent AcceptButtonContent = DefaultAcceptButtonContent;
        public event Action OnAccept;

        public GUIContent CancelButtonContent = DefaultCancelButtonContent;
        public event Action OnCancel;

        private Tab tabIndex = 0;

        public static PrototypeDetailsWindow Initialize(PrototypeData prototypeData)
        {   
            var window = EditorWindow.GetWindow<PrototypeDetailsWindow>(true, prototypeData.Name + " - " + WindowCaption, true);

            window.PrototypeData = prototypeData;

            window.AcceptButtonContent = DefaultAcceptButtonContent;
            window.OnAccept = null;
            window.CancelButtonContent = DefaultCancelButtonContent;
            window.OnCancel = null;

            return window;
        }
        
        private void AcceptButtonClick()
        {
            if (OnAccept != null)
            {
                OnAccept();
            }
        }

        private void CancelButtonClick()
        {
            if (OnCancel != null)
            {
                OnCancel();
            }

            Close();
        }

        public void OnGUI()
        {
            EditorGUIRoutines.BeginVerticalWithPadding(WindowContentPadding);
            {
                EditorGUILayout.BeginHorizontal( GUI.skin.box );
                {
                    EditorGUIRoutines.BeginHorizontalWithPadding(TabToolbarPadding);
                    {
                        tabIndex = (Tab)GUILayout.Toolbar((int)tabIndex, TabsContent);

                        GUILayout.FlexibleSpace();
                    }
                    EditorGUIRoutines.EndHorizontalWithPadding(TabToolbarPadding);
                }
                EditorGUILayout.EndHorizontal();                

                EditorGUILayout.BeginHorizontal(GUI.skin.box, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
                {
                    EditorGUIRoutines.BeginVerticalWithPadding(TabContentPadding);
                    {
                        if(tabIndex == Tab.Description)
                        {
                            EditorGUILayout.BeginHorizontal();
                            {
                                GUILayout.Label(NameLabelContent, GUILayout.Width(LabelWidth));
                                PrototypeData.Name = EditorGUILayout.TextField(PrototypeData.Name);
                            }
                            EditorGUILayout.EndHorizontal();

                            GUILayout.Space(SmallSpace);

                            EditorGUILayout.BeginHorizontal();
                            {
                                GUILayout.Label(DescriptionLabelContent, GUILayout.Width(LabelWidth));
                                PrototypeData.Description = EditorGUILayout.TextArea(PrototypeData.Description, GUILayout.Height(DescriptionAreaHeight));
                            }
                            EditorGUILayout.EndHorizontal();

                            GUILayout.Space(SmallSpace);

                            EditorGUILayout.BeginHorizontal();
                            {
                                GUILayout.Label(IsEnabledContent, GUILayout.Width(LabelWidth));
                                PrototypeData.IsEnabled = GUILayout.Toggle(PrototypeData.IsEnabled, GUIContent.none);
                            }
                            EditorGUILayout.EndHorizontal();
                        }
                        else if(tabIndex == Tab.Keys)
                        {
                            PrototypeData.Keys.ForEach(key =>
                            {
                                EditorGUILayout.BeginHorizontal(GUI.skin.box, GUILayout.ExpandWidth(true));
                                {

                                }
                                EditorGUILayout.EndHorizontal();
                            });

                        }
                        else if(tabIndex == Tab.Objects)
                        {

                        }
                        else if(tabIndex == Tab.Fields)
                        {

                        }
                        else if(tabIndex == Tab.Relations)
                        {

                        }
                    }
                    EditorGUIRoutines.EndVerticalWithPadding(TabContentPadding);
                }
                EditorGUILayout.EndHorizontal();

                GUILayout.Space(NormalSpace);

                EditorGUILayout.BeginHorizontal();
                {
                    GUILayout.FlexibleSpace();

                    if (GUILayout.Button(AcceptButtonContent))
                    {
                        AcceptButtonClick();
                    }

                    if (GUILayout.Button(CancelButtonContent))
                    {
                        CancelButtonClick();
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUIRoutines.EndVerticalWithPadding(WindowContentPadding);
        }
    }
}