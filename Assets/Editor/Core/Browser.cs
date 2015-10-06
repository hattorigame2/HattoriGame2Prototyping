using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace HattoriGame2.Core
{
    public abstract class Browser<T> : EditorWindow
    {
        public enum BrowsingMode
        {
            Browsing,
            SingleSelection,
            MultipleSelection
        }

        public BrowsingMode Mode;

        public static void ShowAsBrowser()
        {
            var window = GetWindow<Browser<T>>();
            window.Mode = BrowsingMode.Browsing;
            window.Show();
            window.Focus();
        }

        public static void ShowAsSelectionDialog(bool isMultipleSelection, List<T> PreviousSelection )
        {
            var window = GetWindow<Browser<T>>();
            window.Mode = isMultipleSelection ? BrowsingMode.MultipleSelection : BrowsingMode.SingleSelection;
            window.Show();
            window.Focus();
        }

        protected virtual GUIContent GetCaption()
        {
            return new GUIContent(string.Empty);
        }

        public void Filter()
        {

        }

        public void Sort()
        {

        }

        
        private void OnEnable()
        {

        }
        
        private void OnGUI()
        {
            titleContent = GetCaption();

        }
    }
}
