using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class InspectMaterials
{
    public static void Inspect()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Main.unity", OpenSceneMode.Single);
        var gp = GameObject.Find("GroundPlane");
        if (gp != null)
        {
            var mr = gp.GetComponent<MeshRenderer>();
            Debug.Log($"GroundPlane material: {(mr != null && mr.sharedMaterial != null ? mr.sharedMaterial.name : "null")}");
        }
        var cliff = GameObject.Find("Cliff");
        if (cliff != null)
        {
            var mr = cliff.GetComponent<MeshRenderer>();
            Debug.Log($"Cliff material: {(mr != null && mr.sharedMaterial != null ? mr.sharedMaterial.name : "null")}");
        }
        var tree = GameObject.Find("Tree");
        if (tree != null)
        {
            var mr = tree.GetComponent<MeshRenderer>();
            if (mr != null)
            {
                foreach (var mat in mr.sharedMaterials)
                    Debug.Log($"Tree material: {(mat != null ? mat.name : "null")}");
            }
        }
    }
}
