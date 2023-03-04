using UnityEditor;
using UnityEditor.AnimatedValues;

public class SpawnGameObjectExtraFields
{
    public ExtraFields ExtraFields;
    
    public void DisplayExtraFields(AnimBool showExtraFields)
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