using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueStarter))]
[CanEditMultipleObjects]
public class E_DialogueStarter : Editor
{
    SerializedProperty dialogue;
    SerializedProperty onDialogueEnded;
    SerializedProperty onDialogueStarted;

    private void OnEnable()
    {
        dialogue = serializedObject.FindProperty("m_Dialogue");
        onDialogueEnded = serializedObject.FindProperty("m_OnDialogueEnded");
        onDialogueStarted = serializedObject.FindProperty("m_OnDialogueStarted");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (Application.isPlaying)
        {
            if (GUILayout.Button("Run dialogue"))
            {
                DialogueStarter starter = (DialogueStarter)target;
                starter.StartDialogue();
            }
        }

        EditorGUILayout.PropertyField(dialogue);
        EditorGUILayout.PropertyField(onDialogueStarted);
        EditorGUILayout.PropertyField(onDialogueEnded);

        serializedObject.ApplyModifiedProperties();
    }
}