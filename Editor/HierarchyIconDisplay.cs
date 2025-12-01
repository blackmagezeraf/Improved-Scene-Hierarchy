using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

namespace ImprovedSceneHierarchy {

    [InitializeOnLoad]
    public static class HierarchyIconDisplay {
        static bool _hierarchyHasFocus = false;
        static EditorWindow _hierarchyEditorWindow;

        static HierarchyIconDisplay() {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
            EditorApplication.update += OnEditorUpdate;
        }

        private static void OnEditorUpdate() {
            if (_hierarchyHasFocus)
                _hierarchyEditorWindow = EditorWindow.GetWindow(Type.GetType("UnityEditor.SceneHierarchyWindow, UnityEditor"));

            _hierarchyHasFocus = EditorWindow.focusedWindow != null && EditorWindow.focusedWindow == _hierarchyEditorWindow;
        }

        private static void OnHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect) {
            GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (obj == null)
                return;

            if (PrefabUtility.GetCorrespondingObjectFromOriginalSource(obj) != null)
                return;

            Component[] components = obj.GetComponents<Component>();
            if (components == null || components.Length == 0)
                return;

            Component component = components.Length > 1 ? components[1] : components[0];

            Type type = component.GetType();

            GUIContent content = EditorGUIUtility.ObjectContent(component, type);
            content.text = null;
            content.tooltip = type.Name;

            if (content.image == null)
                return;

            bool isSelected = Selection.instanceIDs.Contains(instanceID);
            bool isHovered = selectionRect.Contains(Event.current.mousePosition);
            bool isFocused = _hierarchyHasFocus;

            Color color = UnityEditorBackgroundColor.Get(isSelected, isHovered, isFocused);
            Rect backgroundRect = selectionRect;
            backgroundRect.width = 18f;

            EditorGUI.DrawRect(backgroundRect, color);

            EditorGUI.LabelField(selectionRect, content);
        }
    }
}