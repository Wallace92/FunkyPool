using System;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class SpawnGameObjectsTool : EditorWindow
{
    private GameObject m_prefab;
    private Transform m_prefabContainer;
    private Vector3 m_position = Vector3.zero;
    
    private bool m_addId = true;
    private string m_objectName;
    
    private int objectID;
    private bool extraOptions;
    
    AnimBool m_ShowExtraFields;

    private readonly SpawnGameObjectHelpMessages m_spawnGameObjectHelpMessages = new SpawnGameObjectHelpMessages();
    
    [MenuItem("Tools/SpawnGameObjects")]
    private static void Init()
    {
        SpawnGameObjectsTool window = (SpawnGameObjectsTool)EditorWindow.GetWindow(typeof(SpawnGameObjectsTool));
    }

    void OnEnable()
    {
        m_ShowExtraFields = new AnimBool(true);
        m_ShowExtraFields.valueChanged.AddListener(Repaint);
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn GameObject", EditorStyles.boldLabel);

        EssentialFields();
        
        EditorGUILayout.Space();
        
        SpawnButton();
        
        EditorGUILayout.Space();

        m_spawnGameObjectHelpMessages.HelpMessage(m_prefab, m_objectName, m_prefabContainer);

        m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("Show extra fields", m_ShowExtraFields.target);
        
        if (EditorGUILayout.BeginFadeGroup(m_ShowExtraFields.faded))
        {
            EditorGUI.indentLevel++;
            
            AddNumericalIdGui();
            
            m_position = EditorGUILayout.Vector3Field("Position", m_position);

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndFadeGroup();
    }
    
    private void AddNumericalIdGui()
    {
        m_addId = EditorGUILayout.BeginToggleGroup("AddID", m_addId);
        EditorGUI.indentLevel++;
        objectID = EditorGUILayout.IntField("Object ID", objectID);
        EditorGUI.indentLevel--;
        EditorGUILayout.EndToggleGroup();
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
        GameObject newObject = Instantiate(m_prefab, m_position, Quaternion.identity, m_prefabContainer);
        newObject.name = m_addId ? m_objectName + "_" + objectID : m_objectName;

        if (m_addId)
            objectID++;
    }
}