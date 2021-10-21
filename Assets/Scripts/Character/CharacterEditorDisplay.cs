using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
namespace Assets.Scripts.Character
{
    [CreateAssetMenu(menuName = ("Editor Display/Character"))]
    [Serializable]
    public class CharacterEditorDisplay:ScriptableObject
    {
        //public List<Character> m_characters = new List<Character>(2);
        private void OnEnable() {
            //m_characters.Add(new Character());
            //m_characters.Add(new Character(8));
        }
    }

#if UNITY_EDITOR
    /// <summary>
    /// Custom ReadOnly from https://forum.unity.com/threads/serialize-readonly-field.426525/.
    /// This variable needs to be replaced with actual 'readonly' later
    /// </summary>
    public class ReadOnlyAttribute:PropertyAttribute { }
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer:PropertyDrawer
    {
        public override void OnGUI(Rect position,SerializedProperty property,GUIContent label) {
            var previousGUIState = GUI.enabled;

            GUI.enabled = false;

            EditorGUI.PropertyField(position,property,label);

            GUI.enabled = previousGUIState;
        }
    }
#endif
}