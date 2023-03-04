using System;
using UnityEditor;
using UnityEngine;

public class SpawnGameObjectHelpMessages
{
    public void HelpMessage(GameObject prefab, string prefabName, Transform prefabContainer)
    {
        if (prefab == null)
            EditorGUILayout.HelpBox("Place a Prefab to Spawn.", 
                MessageType.Warning);

        if (String.IsNullOrEmpty(prefabName))
            EditorGUILayout.HelpBox("Assign a name to the object to be spawned.", 
                MessageType.Warning);

        if (prefabContainer != null && EditorUtility.IsPersistent(prefabContainer))
            EditorGUILayout.HelpBox("Object Container must be a scene object.", 
                MessageType.Warning);
    }
}