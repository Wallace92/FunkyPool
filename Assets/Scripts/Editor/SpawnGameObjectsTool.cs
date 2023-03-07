using System;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class SpawnGameObjectsTool : EditorWindow
{
    private GameObject m_prefab;
    private Transform m_prefabContainer;
    private AnimBool m_showExtraFields;
    
    private string m_objectName;
    
    private readonly SpawnGameObjectExtraFields m_spawnGameObjectExtraFields = new SpawnGameObjectExtraFields();

    [MenuItem("Tools/SpawnGameObject")]
    private static void ShowWindow() => GetWindow(typeof(SpawnGameObjectsTool));

    private void OnEnable()
    {
        m_showExtraFields = new AnimBool(true);
        m_showExtraFields.speed = 8;
        m_showExtraFields.valueChanged.AddListener(Repaint);
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn GameObject", EditorStyles.boldLabel);

        EssentialFields();

        if (String.IsNullOrEmpty(m_objectName) && m_prefab != null)
            m_objectName = m_prefab.name;
        
        SpawnButton(m_prefab, m_prefabContainer, m_objectName, m_spawnGameObjectExtraFields);
        
        EditorGUILayout.Space();
        
        SpawnGameObjectHelpMessages.HelpMessage(m_prefab, m_objectName, m_prefabContainer);
        
        m_spawnGameObjectExtraFields.DisplayExtraFields(m_showExtraFields);
    }

    private void EssentialFields()
    {
        EditorGUILayout.Space();

        m_objectName = EditorGUILayout.TextField("Name", m_objectName);
        m_prefab = EditorGUILayout.ObjectField("Prefab", m_prefab, typeof(GameObject), false) as GameObject;
        m_prefabContainer = EditorGUILayout.ObjectField("Object Container", m_prefabContainer, typeof(Transform), true) as Transform;

        EditorGUILayout.HelpBox("Not required", MessageType.None, false);
    }
    
    private void SpawnButton(GameObject prefab,  Transform prefabContainer, string prefabName, SpawnGameObjectExtraFields  spawnGameObjectExtraFields)
    {
        EditorGUILayout.Space();
        
        var nameNotAssigment = String.IsNullOrEmpty(prefabName);
        var prefabNotAssigment = prefab == null;
        var prefabContainerOnDisc = prefabContainer != null && EditorUtility.IsPersistent(prefabContainer);

        var isDisabled = nameNotAssigment || prefabNotAssigment || prefabContainerOnDisc;
        
        EditorGUI.BeginDisabledGroup(isDisabled); // true -> disabled

        if (GUILayout.Button("Spawn Object"))
            SpawnObjects(prefab, prefabContainer, spawnGameObjectExtraFields);

        EditorGUI.EndDisabledGroup();
    }
    
    private void SpawnObjects(GameObject prefab,  Transform prefabContainer, SpawnGameObjectExtraFields spawnGameObjectExtraFields)
    {
        var extraFields = spawnGameObjectExtraFields.ExtraFields;
        
        GameObject spawnedObject = Instantiate(prefab, extraFields.Position, Quaternion.identity, prefabContainer);
        
        spawnedObject.name = extraFields.AddId 
            ? m_objectName + "_" + extraFields.Id
            : m_objectName;

        if (extraFields.AddId)
            spawnGameObjectExtraFields.IncrementObjectId();
    }
    
    private void OnFocus() => SceneView.duringSceneGui += OnSceneGUI;

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
        SceneView.RepaintAll();
    }

    private void OnDestroy() => SceneView.duringSceneGui -= OnSceneGUI;

    private void OnSceneGUI(SceneView sceneView)
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(m_spawnGameObjectExtraFields.ExtraFields.Position, Vector3.up, 0.5f);
    }
}