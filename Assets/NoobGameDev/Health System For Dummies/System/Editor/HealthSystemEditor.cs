using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HealthSystemForDummies))]
[CanEditMultipleObjects]
public class HealthSystemEditor : Editor
{
    float currentHealthPercentage;

    // Caches
    HealthSystemForDummies healthSystem;

    SerializedProperty maximumHealth;
    SerializedProperty currentHealth;
    SerializedProperty isAlive;
    SerializedProperty hasAnimationWhenHealthChanges;
    SerializedProperty animationDuration;

    SerializedProperty onCurrentHealthChanged;
    SerializedProperty onIsAliveChanged;
    SerializedProperty onMaximumHealthChanged;

    SerializedProperty healthBarPrefabToSpawn;

    GameObject gameObject;

    void OnEnable()
    {
        healthSystem = target as HealthSystemForDummies;
        gameObject = healthSystem.gameObject;

        maximumHealth = serializedObject.FindProperty("MaximumHealth");
        currentHealth = serializedObject.FindProperty("CurrentHealth");
        isAlive = serializedObject.FindProperty("IsAlive");
        hasAnimationWhenHealthChanges = serializedObject.FindProperty("HasAnimationWhenHealthChanges");
        animationDuration = serializedObject.FindProperty("AnimationDuration");
        onCurrentHealthChanged = serializedObject.FindProperty("OnCurrentHealthChanged");
        onIsAliveChanged = serializedObject.FindProperty("OnIsAliveChanged");
        onMaximumHealthChanged = serializedObject.FindProperty("OnMaximumHealthChanged");
        healthBarPrefabToSpawn = serializedObject.FindProperty("HealthBarPrefabToSpawn");
    }

    public override void OnInspectorGUI()
    {
        bool _beforeIsAlive = isAlive.boolValue;
        float _beforeCurrentHealth = currentHealth.floatValue;

        serializedObject.Update();

        GUI.enabled = false;
        EditorGUILayout.Toggle("Is Alive", isAlive.boolValue);
        GUI.enabled = true;

        EditorGUI.BeginChangeCheck();
        maximumHealth.floatValue = EditorGUILayout.FloatField("Maximum Health", maximumHealth.floatValue);
        if (EditorGUI.EndChangeCheck())
        {
            maximumHealth.floatValue = Mathf.Clamp(maximumHealth.floatValue, 0, float.MaxValue);
            currentHealth.floatValue = maximumHealth.floatValue * (currentHealthPercentage / 100);
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Current Health", EditorStyles.boldLabel);
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUI.BeginChangeCheck();
            currentHealth.floatValue = EditorGUILayout.FloatField("Current Health", currentHealth.floatValue);
            if (EditorGUI.EndChangeCheck())
            {
                currentHealth.floatValue = Mathf.Clamp(currentHealth.floatValue, 0, maximumHealth.floatValue);
                currentHealthPercentage = (currentHealth.floatValue / healthSystem.MaximumHealth) * 100;
            }

            EditorGUI.BeginChangeCheck();
            currentHealthPercentage = EditorGUILayout.Slider("Current Health Percentage", (currentHealth.floatValue / maximumHealth.floatValue) * 100, 0, 100);
            if (EditorGUI.EndChangeCheck())
            {
                currentHealth.floatValue = healthSystem.MaximumHealth * (currentHealthPercentage / 100);
            }
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Smooth Animation When Health Changes", EditorStyles.boldLabel);
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            hasAnimationWhenHealthChanges.boolValue = EditorGUILayout.Toggle("Has Smooth Animation", hasAnimationWhenHealthChanges.boolValue);

            if (hasAnimationWhenHealthChanges.boolValue)
            {
                animationDuration.floatValue = EditorGUILayout.Slider("Animation Duration", animationDuration.floatValue, 0f, 2f);
            }
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Add Health Bar Object To The Scene", EditorStyles.boldLabel);
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.PropertyField(healthBarPrefabToSpawn);

            if (GUILayout.Button("Add Health Bar"))
            {
                GameObject spawnedHealthBar = Utilities.Instance.Prefab.Instantiate(healthSystem.HealthBarPrefabToSpawn);
                spawnedHealthBar.transform.position = gameObject.transform.position;
                spawnedHealthBar.transform.rotation = gameObject.transform.rotation;
                spawnedHealthBar.transform.SetParent(gameObject.transform);
            }
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("On Change Events", EditorStyles.boldLabel);
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.PropertyField(onIsAliveChanged);
            EditorGUILayout.PropertyField(onCurrentHealthChanged);
            EditorGUILayout.PropertyField(onMaximumHealthChanged);
        }

        isAlive.boolValue = currentHealth.floatValue > 0;

        serializedObject.ApplyModifiedProperties();

        bool currentIsAlive = isAlive.boolValue;
        if (currentIsAlive != _beforeIsAlive)
        {
            healthSystem.OnIsAliveChanged.Invoke(currentIsAlive);
        }

        float currentCurrentHealth = currentHealth.floatValue;
        if (currentCurrentHealth != _beforeCurrentHealth)
        {
            healthSystem.OnCurrentHealthChanged.Invoke(
                new CurrentHealth(
                    _beforeCurrentHealth,
                    currentCurrentHealth,
                    currentHealthPercentage
                )
            );
        }
    }
}
