#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class PrefabUtilities
{
    public PrefabUtilities() { }

    public GameObject Instantiate(GameObject prefab)
    {
#if UNITY_EDITOR
        GameObject gameObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        Undo.RegisterCreatedObjectUndo(gameObject, $"Spawn {gameObject.transform.name}");
        return gameObject;
#else
    return prefab;
#endif
    }
}
