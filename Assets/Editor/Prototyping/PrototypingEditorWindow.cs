using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;

namespace HattoriGame2.Prototyping.Editor
{
    public sealed class PrototypingEditorWindow : EditorWindow
    {
        // Strings
        private const string WindowCaption = "Prototyping Tool";
        private const string RemoveDialogCaption = "Remove";
        private const string RemoveDialogText = "Are you want's to remove this prototype?";
        private const string RemoveDialogOK = "OK";
        private const string RemoveDialogCancel = "Cancel";
        private const string HelpURL = "http://google.com";

        private static readonly GUIContent AddButtonContent = new GUIContent("Add...");
        private static readonly GUIContent EditButtonContent = new GUIContent("Edit...");
        private static readonly GUIContent MoveUpButtonContent = new GUIContent("↑");
        private static readonly GUIContent MoveDownButtonContent = new GUIContent("↓");
        private static readonly GUIContent RemoveButtonContent = new GUIContent("Remove");
        private static readonly GUIContent HelpButtonContent = new GUIContent( "Help" );
        private static readonly GUIContent ApplyButtonContent = new GUIContent("Apply");
        private static readonly GUIContent SettingsButtonContent = new GUIContent("Settings...");
        private static readonly GUIContent CloseButtonContent = new GUIContent( "Close" );

        private static readonly GUIContent IsEnabledContent = new GUIContent("", "Is tutorial(s) enabled?");
        private static readonly GUIContent SelectionContent = new GUIContent("", "Select this prototype");

        private const float ToolsPanelWidth = 200f;
        private const float NormalSpace = 10f;
        private const float SmallSpace = 5f;
        private const float SelectorSize = 15f;
        private const float HeaderRowHeight = 20f;
        private const float RowHeight = 50f;
        private const float NameColumnWidth = 150;
        private const float DescriptionColumnWidth = 300f;
        private const float EnabledColumnWidth = 15f;

        private static readonly Color SelectedBackgroundColor = new Color(1.0f, 1.0f, 1.0f);
        private static readonly Color NotSelectedBackgroundColor = new Color(0.8f, 0.8f, 0.8f);

        private static int? selectedIndex = null;
        private static Vector2 prototypesScrollViewPosition = Vector2.zero;

        [MenuItem("Tools/Prototyping")]
        public static void Initialize()
        {
            EditorWindow.GetWindow<PrototypingEditorWindow>(true, WindowCaption, true);
        }

        private void AddButtonClick()
        {
            var prototypeData = new PrototypeData();

            var window = PrototypeDetailsWindow.Initialize( prototypeData );

            window.AcceptButtonContent = new GUIContent("Create");
            window.OnAccept += () =>
            {
                if (selectedIndex.HasValue)
                {
                    PrototypingEditorSystem.Asset.Prototypes.Insert((int)selectedIndex, prototypeData);
                }
                else
                {
                    PrototypingEditorSystem.Asset.Prototypes.Add(prototypeData);
                }

                window.Close();
            };
        }

        private void EditButtonClick( PrototypeData prototypeData )
        {
            var window = PrototypeDetailsWindow.Initialize(prototypeData);

            window.AcceptButtonContent = new GUIContent("Apply");
            window.OnAccept += () =>
                {                    
                    PrototypingEditorSystem.Save();
                };

            window.OnCancel += () =>
                {

                };
        }

        private void MoveDownButtonClick()
        {
            throw new System.NotImplementedException();
        }

        private void MoveUpButtonClick()
        {
            throw new System.NotImplementedException();
        }

        private void RemoveButtonClick( PrototypeData prototypeData )
        {
            if ( selectedIndex.HasValue && EditorUtility.DisplayDialog(RemoveDialogCaption, RemoveDialogText, RemoveDialogOK, RemoveDialogCancel))
            {
                PrototypingEditorSystem.Asset.Prototypes.Remove(prototypeData);
                selectedIndex = null;
            }
        }

        private void SettingsButtonClick()
        {
            PrototypingSettingsEditorWindow.Initialize();
        }

        private void HelpButtonClick()
        {
            Application.OpenURL(HelpURL);
        }

        private void ApplyButtonClick()
        {
            PrototypingEditorSystem.Save();
        }

        private void CloseButtonClick()
        {
            Close();
        }

        public void OnGUI()
        {
            GUILayout.Space(NormalSpace);

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Space(NormalSpace);

                EditorGUILayout.BeginVertical();
                {
                    EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.Height(HeaderRowHeight));
                    {
                        GUILayout.Space(SmallSpace);

                        EditorGUILayout.BeginHorizontal();
                        {
                            GUILayout.Space(SmallSpace);

                            var oldIsAllEnabled = PrototypingEditorSystem.Asset.Prototypes.TrueForAll(prototypeData => prototypeData.IsEnabled);

                            var newIsAllEnabled = GUILayout.Toggle(oldIsAllEnabled, IsEnabledContent, GUI.skin.button, GUILayout.Width(EnabledColumnWidth), GUILayout.ExpandHeight(true));

                            if (oldIsAllEnabled != newIsAllEnabled)
                            {
                                PrototypingEditorSystem.Asset.Prototypes.ForEach(prototypeData =>
                                {
                                    prototypeData.IsEnabled = newIsAllEnabled;
                                });
                            }

                            GUILayout.Box(GUIContent.none, GUILayout.ExpandHeight(true));
                        }
                        EditorGUILayout.EndHorizontal();

                        GUILayout.Space(SmallSpace);
                    }
                    EditorGUILayout.EndVertical();

                    GUILayout.Space(NormalSpace);

                    EditorGUILayout.BeginVertical();
                    {
                        for (int i = 0; i < PrototypingEditorSystem.Asset.Prototypes.Count; i++)
                        {
                            var oldBackgroundColor = GUI.backgroundColor;

                            var prototype = PrototypingEditorSystem.Asset.Prototypes[i];
                            var oldIsSelected = selectedIndex.HasValue && selectedIndex == i;
                            bool newIsSelected = oldIsSelected;

                            GUI.backgroundColor = oldIsSelected ? SelectedBackgroundColor : NotSelectedBackgroundColor;

                            EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.Height(RowHeight));
                            {
                                GUILayout.Space(SmallSpace);

                                EditorGUILayout.BeginHorizontal();
                                {
                                    GUILayout.Space(SmallSpace);

                                    prototype.IsEnabled = GUILayout.Toggle(prototype.IsEnabled, IsEnabledContent, GUI.skin.button, GUILayout.Width(EnabledColumnWidth), GUILayout.ExpandHeight(true));

                                    GUILayout.Box(GUIContent.none, GUILayout.ExpandHeight(true));

                                    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
                                    prototype.Name = EditorGUILayout.TextField(prototype.Name, GUI.skin.label, GUILayout.Width(NameColumnWidth), GUILayout.ExpandHeight(true));
                                    prototype.Description = EditorGUILayout.TextArea(prototype.Description, GUILayout.Width(DescriptionColumnWidth), GUILayout.ExpandHeight(true));

                                    GUILayout.FlexibleSpace();

                                    GUILayout.Box(GUIContent.none, GUILayout.ExpandHeight(true));
                                    newIsSelected = GUILayout.Toggle(oldIsSelected, SelectionContent, GUI.skin.button, GUILayout.Width(SelectorSize), GUILayout.ExpandHeight(true));
                                }
                                EditorGUILayout.EndHorizontal();

                                GUILayout.Space(SmallSpace);
                            }
                            EditorGUILayout.EndVertical();

                            if (oldIsSelected != newIsSelected)
                            {
                                selectedIndex = newIsSelected ? i : (int?)null;
                            }

                            GUI.backgroundColor = oldBackgroundColor;
                        }
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndVertical();

                GUILayout.Space(NormalSpace);

                EditorGUILayout.BeginVertical(GUILayout.Width(ToolsPanelWidth));
                {
                    if (GUILayout.Button(AddButtonContent))
                    {
                        AddButtonClick();
                    }

                    if (!selectedIndex.HasValue)
                    {
                        GUI.enabled = false;
                    }

                    if (GUILayout.Button(EditButtonContent))
                    {
                        EditButtonClick(PrototypingEditorSystem.Asset.Prototypes[(int)selectedIndex]);
                    }

                    EditorGUILayout.BeginHorizontal();
                    {
                        if (GUILayout.Button(MoveUpButtonContent))
                        {
                            MoveUpButtonClick();
                        }

                        if (GUILayout.Button(MoveDownButtonContent))
                        {
                            MoveDownButtonClick();
                        }
                    }
                    EditorGUILayout.EndHorizontal();

                    if (GUILayout.Button(RemoveButtonContent))
                    {
                        RemoveButtonClick(PrototypingEditorSystem.Asset.Prototypes[(int)selectedIndex]);
                    }

                    GUI.enabled = true;

                    GUILayout.FlexibleSpace();

                    if (GUILayout.Button(HelpButtonContent))
                    {
                        HelpButtonClick();
                    }

                    if (!PrototypingEditorSystem.IsDirty)
                    {
                        GUI.enabled = false;
                    }

                    if (GUILayout.Button(ApplyButtonContent))
                    {
                        ApplyButtonClick();
                    }

                    GUI.enabled = true;

                    if (GUILayout.Button(SettingsButtonContent))
                    {
                        SettingsButtonClick();
                    }

                    if (GUILayout.Button(CloseButtonContent))
                    {
                        CloseButtonClick();
                    }
                }
                EditorGUILayout.EndVertical();

                GUILayout.Space(NormalSpace);

            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(NormalSpace);
        }
    }
}