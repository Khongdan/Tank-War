using UnityEngine;
using UnityEditor;
using System.IO;

public class PrefabInspector
{
    public static void InspectTank()
    {
        GameObject tank = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Tank.prefab");
        using (StreamWriter writer = new StreamWriter("tank_prefab_info.txt", false))
        {
            writer.WriteLine($"Tank: {tank.name}");
            DumpHierarchy(tank.transform, "", writer);
        }
        Debug.Log("Dumped tank prefab info");
    }

    private static void DumpHierarchy(Transform t, string indent, StreamWriter writer)
    {
        writer.WriteLine($"{indent}- {t.name} pos={t.localPosition}, rot={t.localEulerAngles}, scale={t.localScale}");
        foreach (var c in t.GetComponents<Component>())
        {
            if (c != null)
                writer.WriteLine($"{indent}    * {c.GetType().FullName}");
        }
        for (int i = 0; i < t.childCount; i++)
        {
            DumpHierarchy(t.GetChild(i), indent + "  ", writer);
        }
    }
}
