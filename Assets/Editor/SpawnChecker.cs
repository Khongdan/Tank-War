using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SpawnChecker
{
    public static void Check()
    {
        EditorSceneManager.OpenScene("Assets/_Complete-Game.unity", OpenSceneMode.Single);
        var sp1 = GameObject.Find("SpawnPoint1");
        var sp2 = GameObject.Find("SpawnPoint2");
        Debug.Log($"_Complete-Game sp1: {(sp1 != null ? sp1.transform.position.ToString() : "null")}");
        Debug.Log($"_Complete-Game sp2: {(sp2 != null ? sp2.transform.position.ToString() : "null")}");
    }
}
