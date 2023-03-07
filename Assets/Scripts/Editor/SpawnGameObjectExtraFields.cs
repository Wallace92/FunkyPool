using UnityEditor;
using UnityEditor.AnimatedValues;

public class SpawnGameObjectExtraFields
{
    public SpawnObjectExtraFieldsData SpawnObjectExtraFieldsData;
    
    public void DisplayExtraFields(AnimBool showExtraFields)
    {
        showExtraFields.target = EditorGUILayout.ToggleLeft("Show extra fields", showExtraFields.target);

        if (EditorGUILayout.BeginFadeGroup(showExtraFields.faded))
        {
            EditorGUI.indentLevel++;

            AddNumericalIdGui();

            SpawnObjectExtraFieldsData.Position = EditorGUILayout.Vector3Field("Position",  SpawnObjectExtraFieldsData.Position);

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndFadeGroup();
    }

    public void IncrementObjectId() => SpawnObjectExtraFieldsData.Id++;
    
    private void AddNumericalIdGui()
    {
        SpawnObjectExtraFieldsData.AddId = EditorGUILayout.BeginToggleGroup("AddID", SpawnObjectExtraFieldsData.AddId);
        
        EditorGUI.indentLevel++;
        
        SpawnObjectExtraFieldsData.Id = EditorGUILayout.IntField("Object ID", SpawnObjectExtraFieldsData.Id);
        
        EditorGUI.indentLevel--;
        EditorGUILayout.EndToggleGroup();
    }
}