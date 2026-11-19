using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class DecorInspector
{
    public static void ListAllDecor()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Main.unity", OpenSceneMode.Single);
        var levelArt = GameObject.Find("LevelArt");
        using (StreamWriter writer = new StreamWriter("decor_list.txt", false))
        {
            if (levelArt == null)
            {
                writer.WriteLine("LevelArt not found");
                return;
            }
            ListChildren(levelArt.transform, "", writer);
        }
        Debug.Log("Dumped decor list");
    }

    private static void ListChildren(Transform parent, string prefix, StreamWriter writer)
    {
        foreach (Transform child in parent)
        {
            writer.WriteLine($"{prefix}{child.name} | pos=({child.localPosition.x:F2}, {child.localPosition.y:F2}, {child.localPosition.z:F2}) | rot=({child.localEulerAngles.x:F2}, {child.localEulerAngles.y:F2}, {child.localEulerAngles.z:F2}) | scale=({child.localScale.x:F2}, {child.localScale.y:F2}, {child.localScale.z:F2})");
            if (child.childCount > 0 && child.name != "PumpJack" && child.name != "PumpJack (1)" && child.name != "PumpJack (2)")
            {
                ListChildren(child, prefix + "  ", writer);
            }
        }
    }
}
