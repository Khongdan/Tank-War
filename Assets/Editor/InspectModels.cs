using UnityEngine;
using UnityEditor;

public class InspectModels
{
    public static void Inspect()
    {
        var tankSubAssets = AssetDatabase.LoadAllAssetsAtPath("Assets/Models/Tank.fbx");
        Debug.Log($"=== Tank.fbx ({tankSubAssets.Length} sub-assets) ===");
        foreach (var obj in tankSubAssets)
        {
            if (obj is Mesh mesh)
                Debug.Log($"  Mesh: {mesh.name}, verts={mesh.vertexCount}");
        }

        var bustedSubAssets = AssetDatabase.LoadAllAssetsAtPath("Assets/Models/BustedTank.fbx");
        Debug.Log($"=== BustedTank.fbx ({bustedSubAssets.Length} sub-assets) ===");
        foreach (var obj in bustedSubAssets)
        {
            if (obj is Mesh mesh)
                Debug.Log($"  Mesh: {mesh.name}, verts={mesh.vertexCount}");
        }
    }
}
