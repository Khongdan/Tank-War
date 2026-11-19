using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class GameManagerInspector
{
    public static void InspectGM()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Main.unity", OpenSceneMode.Single);
        var gm = Object.FindFirstObjectByType<GameManager>();
        using (StreamWriter writer = new StreamWriter("gm_info.txt", false))
        {
            if (gm == null)
            {
                writer.WriteLine("GameManager not found!");
                return;
            }
            writer.WriteLine($"NumRoundsToWin: {gm.m_NumRoundsToWin}");
            writer.WriteLine($"StartDelay: {gm.m_StartDelay}");
            writer.WriteLine($"EndDelay: {gm.m_EndDelay}");
            writer.WriteLine($"CameraControl: {(gm.m_CameraControl != null ? gm.m_CameraControl.name : "null")}");
            writer.WriteLine($"MessageText: {(gm.m_MessageText != null ? gm.m_MessageText.name : "null")}");
            writer.WriteLine($"TankPrefab: {(gm.m_TankPrefab != null ? gm.m_TankPrefab.name : "null")}");
            writer.WriteLine($"Tanks length: {(gm.m_Tanks != null ? gm.m_Tanks.Length : 0)}");
            if (gm.m_Tanks != null)
            {
                for (int i = 0; i < gm.m_Tanks.Length; i++)
                {
                    var t = gm.m_Tanks[i];
                    writer.WriteLine($"  Tank {i}: Color={t.m_PlayerColor}, SpawnPoint={(t.m_SpawnPoint != null ? t.m_SpawnPoint.name + " " + t.m_SpawnPoint.position : "null")}");
                }
            }
        }
        Debug.Log("Dumped GM info");
    }
}
