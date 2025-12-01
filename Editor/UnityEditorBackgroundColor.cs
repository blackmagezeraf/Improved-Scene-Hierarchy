using UnityEngine;
using UnityEditor;

namespace ImprovedSceneHierarchy {
    public static class UnityEditorBackgroundColor {
        static readonly Color k_defaultColor = new(.7843f, .7843f, .7843f);
        static readonly Color k_defaultDarkColor = new(.2196f, .2196f, .2196f);

        static readonly Color k_selectedColor = new(.22745f, .447f, .6902f);
        static readonly Color k_selectedDarkColor = new(.1725f, .3647f, .5294f);

        static readonly Color k_selectedUnfocusedColor = new(.68f, .68f, .68f);
        static readonly Color k_selectedUnfocusedDarkColor = new(.3f, .3f, .3f);

        static readonly Color k_hoveredColor = new(.698f, .698f, .698f);
        static readonly Color k_hoveredDarkColor = new(.2706f, .2706f, .2706f);

        public static Color Get(bool isSelected, bool isHovered, bool isWindowFocused) {
            if (isSelected) {
                if (isWindowFocused) {
                    return EditorGUIUtility.isProSkin ? k_selectedDarkColor : k_selectedColor;
                } else {
                    return EditorGUIUtility.isProSkin ? k_selectedUnfocusedDarkColor : k_selectedUnfocusedColor;
                }
            } else if (isHovered) {
                return EditorGUIUtility.isProSkin ? k_hoveredDarkColor : k_hoveredColor;
            } else {
                return EditorGUIUtility.isProSkin ? k_defaultDarkColor : k_defaultColor;
            }
        }
    }
}