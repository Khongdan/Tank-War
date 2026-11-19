using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class SceneInspector
{
    public static void InspectMainScene()
    {
        string scenePath = "Assets/Scenes/Main.unity";
        var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
        
        using (StreamWriter writer = new StreamWriter("scene_hierarchy.txt", false))
        {
            writer.WriteLine($"=== SCENE: {scene.name} ({scenePath}) ===");
            var rootObjects = scene.GetRootGameObjects();
            foreach (var root in rootObjects)
            {
                DumpGameObject(root, "", writer);
            }
        }
        Debug.Log("Scene dump completed to scene_hierarchy.txt");
    }

    private static void DumpGameObject(GameObject go, string indent, StreamWriter writer)
    {
        writer.WriteLine($"{indent}- {go.name} [active={go.activeSelf}, pos={go.transform.position}, rot={go.transform.eulerAngles}, scale={go.transform.localScale}]");
        var components = go.GetComponents<Component>();
        foreach (var c in components)
        {
            if (c != null)
            {
                writer.WriteLine($"{indent}    * Component: {c.GetType().FullName}");
            }
        }
        for (int i = 0; i < go.transform.childCount; i++)
        {
            DumpGameObject(go.transform.GetChild(i).gameObject, indent + "  ", writer);
        }
    }
}
