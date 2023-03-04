using System;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class SpawnGameObjectsTool : EditorWindow
{
    private GameObject m_prefab;
    private Transform m_prefabContainer;

    private string m_objectName;
    
    private AnimBool m_showExtraFields;

    private readonly SpawnGameObjectHelpMessages m_spawnGameObjectHelpMessages = new SpawnGameObjectHelpMessages();
    private readonly SpawnGameObjectExtraFields m_spawnGameObjectExtraFields = new SpawnGameObjectExtraFields();
    
    [MenuItem("Tools/SpawnGameObject")]
    private static void ShowWindow() => GetWindow(typeof(SpawnGameObjectsTool));

    private void OnEnable()
    {
        m_showExtraFields = new AnimBool(true);
        m_showExtraFields.valueChanged.AddListener(Repaint);
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn GameObject", EditorStyles.boldLabel);

        EssentialFields();
        
        EditorGUILayout.Space();
        
        SpawnButton();
        
        EditorGUILayout.Space();
        
        m_spawnGameObjectHelpMessages.HelpMessage(m_prefab, m_objectName, m_prefabContainer);
        m_spawnGameObjectExtraFields.Draw(m_showExtraFields);
    }

    private void EssentialFields()
    {
        EditorGUILayout.Space();

        m_objectName = EditorGUILayout.TextField("Name", m_objectName);
        m_prefab = EditorGUILayout.ObjectField("Prefab", m_prefab, typeof(GameObject), false) as GameObject;
        m_prefabContainer = EditorGUILayout.ObjectField("Object Container", m_prefabContainer, typeof(Transform), true) as Transform;

        EditorGUILayout.HelpBox("Not required", MessageType.None, false);
    }
    
    private void SpawnButton()
    {
        var nameNotAssigment = String.IsNullOrEmpty(m_objectName);
        var prefabNotAssigment = m_prefab == null;
        var prefabContainerOnDisc = m_prefabContainer != null && EditorUtility.IsPersistent(m_prefabContainer);

        var isDisabled = nameNotAssigment || prefabNotAssigment || prefabContainerOnDisc;
        
        EditorGUI.BeginDisabledGroup(isDisabled); // true -> disabled

        if (GUILayout.Button("Spawn Object"))
            SpawnObjects();

        EditorGUI.EndDisabledGroup();
    }
    
    private void SpawnObjects()
    {
        var extraFields = m_spawnGameObjectExtraFields.ExtraFields;
        GameObject newObject = Instantiate(m_prefab, extraFields.Position, Quaternion.identity, m_prefabContainer);
        
        newObject.name = extraFields.AddId 
            ? m_objectName + "_" + extraFields.Id
            : m_objectName;

        if (extraFields.AddId)
            m_spawnGameObjectExtraFields.IncrementObjectId();
    }
}