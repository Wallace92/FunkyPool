using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;


public struct ExtraFields
{
    public Vector3 Position;
    public int Id;
    public bool AddId;
}

public class SpawnGameObjectExtraFields
{
    private bool m_addId;
    public ExtraFields ExtraFields;
    
    public void Draw(AnimBool showExtraFields)
    {
        showExtraFields.target = EditorGUILayout.ToggleLeft("Show extra fields", showExtraFields.target);

        if (EditorGUILayout.BeginFadeGroup(showExtraFields.faded))
        {
            EditorGUI.indentLevel++;

            AddNumericalIdGui();

            ExtraFields.Position = EditorGUILayout.Vector3Field("Position",  ExtraFields.Position);

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndFadeGroup();
    }

    public void IncrementObjectId() => ExtraFields.Id++;
    
    private void AddNumericalIdGui()
    {
        ExtraFields.AddId = EditorGUILayout.BeginToggleGroup("AddID", ExtraFields.AddId);
        
        EditorGUI.indentLevel++;
        
        ExtraFields.Id = EditorGUILayout.IntField("Object ID", ExtraFields.Id);
        
        EditorGUI.indentLevel--;
        EditorGUILayout.EndToggleGroup();
    }
}