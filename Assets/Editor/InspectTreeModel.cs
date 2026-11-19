using UnityEngine;
using UnityEditor;

public class InspectTreeModel
{
    public static void Inspect()
    {
        var treeGo = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Models/Tree.fbx");
        var mr = treeGo.GetComponentInChildren<Renderer>();
        Debug.Log($"Tree.fbx renderer: {(mr != null ? mr.name : "null")}");
        if (mr != null)
        {
            for (int i = 0; i < mr.sharedMaterials.Length; i++)
            {
                var m = mr.sharedMaterials[i];
                Debug.Log($"  Mat {i}: {(m != null ? m.name : "null")}");
            }
        }
    }
}
