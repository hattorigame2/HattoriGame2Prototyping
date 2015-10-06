using UnityEngine;
using UnityEditor;

namespace HattoriGame2.Editor
{
    public static class EditorGUIExtendedLayout
    {
        /// <summary>
        /// Начинает вертикальное расположение элементов с внутренним отступом
        /// </summary>
        /// <param name="padding">Размер отступа:<br></br>
        /// <b><c>x</c></b> - отступ слева, <br></br>
        /// <b><c>y</c></b> - отступ справа, <br></br>
        /// <b><c>z</c></b> - отступ сверху, <br></br>
        /// <b><c>w</c></b> - отступ снизу.</param>
        public static Rect BeginVerticalWithPadding(Vector4 padding, GUIStyle style, params GUILayoutOption[] options)
        {
            var result = EditorGUILayout.BeginHorizontal(style, options);
            GUILayout.Space(padding.x);
            EditorGUILayout.BeginVertical(options);
            GUILayout.Space(padding.z);

            return result;
        }

        /// <summary>
        /// Начинает вертикальное расположение элементов с внутренним отступом
        /// </summary>
        /// <param name="padding">Размер отступа:<br></br>
        /// <b><c>x</c></b> - отступ слева, <br></br>
        /// <b><c>y</c></b> - отступ справа, <br></br>
        /// <b><c>z</c></b> - отступ сверху, <br></br>
        /// <b><c>w</c></b> - отступ снизу.</param>
        public static Rect BeginVerticalWithPadding(Vector4 padding, params GUILayoutOption[] options)
        {
            var result = EditorGUILayout.BeginHorizontal(options);
            GUILayout.Space(padding.x);
            EditorGUILayout.BeginVertical(options);
            GUILayout.Space(padding.z);

            return result;
        }

        /// <summary>
        /// Начинает вертикальное расположение элементов с внутренним отступом
        /// </summary>
        /// <param name="padding">Размер отступа:<br></br>
        /// <b><c>x</c></b> - отступ слева, <br></br>
        /// <b><c>y</c></b> - отступ справа, <br></br>
        /// <b><c>z</c></b> - отступ сверху, <br></br>
        /// <b><c>w</c></b> - отступ снизу.</param>
        public static Rect BeginVerticalWithPadding(Vector4 padding)
        {
            var result = EditorGUILayout.BeginHorizontal();
            GUILayout.Space(padding.x);
            EditorGUILayout.BeginVertical();
            GUILayout.Space(padding.z);

            return result;
        }

        /// <summary>
        /// Закрывает вертикальное расположение элементов с внутренним отступом
        /// </summary>
        /// <param name="padding">Размер отступа:<br></br>
        /// <b><c>x</c></b> - отступ слева, <br></br>
        /// <b><c>y</c></b> - отступ справа, <br></br>
        /// <b><c>z</c></b> - отступ сверху, <br></br>
        /// <b><c>w</c></b> - отступ снизу.</param>
        public static void EndVerticalWithPadding(Vector4 padding)
        {
            GUILayout.Space(padding.w);
            EditorGUILayout.EndVertical();
            GUILayout.Space(padding.y);
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// Начинает горизонтальное расположение элементов с внутренним отступом
        /// </summary>
        /// <param name="padding">Размер отступа:<br></br>
        /// <b><c>x</c></b> - отступ слева, <br></br>
        /// <b><c>y</c></b> - отступ справа, <br></br>
        /// <b><c>z</c></b> - отступ сверху, <br></br>
        /// <b><c>w</c></b> - отступ снизу.</param>
        public static void BeginHorizontalWithPadding(Vector4 padding, GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginVertical(style, options);
            GUILayout.Space(padding.z);
            EditorGUILayout.BeginHorizontal(options);
            GUILayout.Space(padding.x);
        }

        /// <summary>
        /// Начинает горизонтальное расположение элементов с внутренним отступом
        /// </summary>
        /// <param name="padding">Размер отступа:<br></br>
        /// <b><c>x</c></b> - отступ слева, <br></br>
        /// <b><c>y</c></b> - отступ справа, <br></br>
        /// <b><c>z</c></b> - отступ сверху, <br></br>
        /// <b><c>w</c></b> - отступ снизу.</param>
        public static void BeginHorizontalWithPadding(Vector4 padding, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginVertical(options);
            GUILayout.Space(padding.z);
            EditorGUILayout.BeginHorizontal(options);
            GUILayout.Space(padding.x);
        }

        /// <summary>
        /// Начинает горизонтальное расположение элементов с внутренним отступом
        /// </summary>
        /// <param name="padding">Размер отступа:<br></br>
        /// <b><c>x</c></b> - отступ слева, <br></br>
        /// <b><c>y</c></b> - отступ справа, <br></br>
        /// <b><c>z</c></b> - отступ сверху, <br></br>
        /// <b><c>w</c></b> - отступ снизу.</param>
        public static void BeginHorizontalWithPadding(Vector4 padding)
        {
            EditorGUILayout.BeginVertical();
            GUILayout.Space(padding.z);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(padding.x);
        }

        /// <summary>
        /// Закрывает горизонтальное расположение элементов с внутренним отступом
        /// </summary>
        /// <param name="padding">Размер отступа:<br></br>
        /// <b><c>x</c></b> - отступ слева, <br></br>
        /// <b><c>y</c></b> - отступ справа, <br></br>
        /// <b><c>z</c></b> - отступ сверху, <br></br>
        /// <b><c>w</c></b> - отступ снизу.</param>
        public static void EndHorizontalWithPadding(Vector4 padding)
        {
            GUILayout.Space(padding.y);
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(padding.w);
            EditorGUILayout.EndVertical();
        }
    }
}