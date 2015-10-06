using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;
using System;

namespace HattoriGame2.Core.Reflection
{
    [CustomPropertyDrawer(typeof(TypePath))]
    public class TypePathPropertyDrawer : PropertyDrawer
    {
        private const float DialogButtonSize = 30f;
        private readonly static GUIContent DialogButtonContent = new GUIContent("...");
        
        private void DialogButtonClick()
        {

        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var value = fieldInfo.GetValue(property.serializedObject.targetObject) as TypePath;
            EditorGUI.LabelField( new Rect(position.x, position.y, position.width - DialogButtonSize, position.height), label, new GUIContent(value.Path.Split(',').FirstOrDefault()));

            if(GUI.Button( new Rect(position.x + position.width - DialogButtonSize, position.y, DialogButtonSize, position.height), DialogButtonContent ))
            {
                DialogButtonClick();
            }                
        }
    }
}