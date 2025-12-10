using UnityEngine;
using UnityEditor;

namespace ImprovedSceneHierarchy {
    public static class UnityEditorBackgroundColor {
        static readonly Color DefaultColor     = new(.7843f, .7843f, .7843f);
        static readonly Color DefaultDarkColor = new(.2196f, .2196f, .2196f);

        static readonly Color SelectedColor     = new(.22745f, .447f, .6902f);
        static readonly Color SelectedDarkColor = new(.1725f, .3647f, .5294f);

        static readonly Color SelectedUnfocusedColor     = new(.68f, .68f, .68f);
        static readonly Color SelectedUnfocusedDarkColor = new(.3f, .3f, .3f);

        static readonly Color HoveredColor     = new(.698f, .698f, .698f);
        static readonly Color HoveredDarkColor = new(.2706f, .2706f, .2706f);

        public static Color Get(bool isSelected, bool isHovered, bool isWindowFocused) {
            if (isSelected) {
                if (isWindowFocused) {
                    return EditorGUIUtility.isProSkin ? SelectedDarkColor : SelectedColor;
                }

                return EditorGUIUtility.isProSkin ? SelectedUnfocusedDarkColor : SelectedUnfocusedColor;
            }

            if (isHovered) {
                return EditorGUIUtility.isProSkin ? HoveredDarkColor : HoveredColor;
            }

            return EditorGUIUtility.isProSkin ? DefaultDarkColor : DefaultColor;
        }
    }
}