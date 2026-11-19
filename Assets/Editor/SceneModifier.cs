using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

public class SceneModifier
{
    private struct TransformData
    {
        public Vector3 pos;
        public Vector3 rot;
        public Vector3 scale;

        public TransformData(float px, float py, float pz, float rx, float ry, float rz, float sx, float sy, float sz)
        {
            pos = new Vector3(px, py, pz);
            rot = new Vector3(rx, ry, rz);
            scale = new Vector3(sx, sy, sz);
        }
    }

    public static void ApplyModificationsToMainScene()
    {
        string scenePath = "Assets/Scenes/Main.unity";
        var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

        Debug.Log("--- 1. Setting up Split Screen 3rd-Person Cameras in CameraRig ---");
        GameObject cameraRig = GameObject.Find("CameraRig");
        if (cameraRig == null)
        {
            cameraRig = new GameObject("CameraRig");
        }
        cameraRig.transform.position = Vector3.zero;
        cameraRig.transform.rotation = Quaternion.identity;

        CameraControl camControl = cameraRig.GetComponent<CameraControl>();
        if (camControl == null)
        {
            camControl = cameraRig.AddComponent<CameraControl>();
        }

        // Camera 1 (Player 1 - Left)
        Transform cam1Transform = cameraRig.transform.Find("Camera1");
        if (cam1Transform == null) cam1Transform = cameraRig.transform.Find("Main Camera");
        GameObject cam1Obj = cam1Transform != null ? cam1Transform.gameObject : new GameObject("Camera1");
        cam1Obj.name = "Camera1";
        cam1Obj.transform.parent = cameraRig.transform;
        Camera cam1 = cam1Obj.GetComponent<Camera>();
        if (cam1 == null) cam1 = cam1Obj.AddComponent<Camera>();
        cam1.rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
        cam1.orthographic = false;
        cam1.fieldOfView = 60f;
        cam1.nearClipPlane = 0.3f;
        cam1.farClipPlane = 500f;
        cam1.clearFlags = CameraClearFlags.Skybox;
        cam1.tag = "MainCamera";

        AudioListener al1 = cam1Obj.GetComponent<AudioListener>();
        if (al1 == null) al1 = cam1Obj.AddComponent<AudioListener>();
        al1.enabled = true;

        // Camera 2 (Player 2 - Right)
        Transform cam2Transform = cameraRig.transform.Find("Camera2");
        GameObject cam2Obj = cam2Transform != null ? cam2Transform.gameObject : new GameObject("Camera2");
        cam2Obj.name = "Camera2";
        cam2Obj.transform.parent = cameraRig.transform;
        Camera cam2 = cam2Obj.GetComponent<Camera>();
        if (cam2 == null) cam2 = cam2Obj.AddComponent<Camera>();
        cam2.rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
        cam2.orthographic = false;
        cam2.fieldOfView = 60f;
        cam2.nearClipPlane = 0.3f;
        cam2.farClipPlane = 500f;
        cam2.clearFlags = CameraClearFlags.Skybox;

        AudioListener al2 = cam2Obj.GetComponent<AudioListener>();
        if (al2 != null)
        {
            Object.DestroyImmediate(al2);
        }

        camControl.m_Camera1 = cam1;
        camControl.m_Camera2 = cam2;
        camControl.m_Distance = 6.5f;
        camControl.m_Height = 3.2f;
        camControl.m_LookAheadDistance = 14.0f;
        camControl.m_LookAheadHeight = 1.8f;
        camControl.m_FollowSpeed = 22.0f;
        camControl.m_TurnSpeed = 18.0f;
        camControl.m_FieldOfView = 60.0f;
        camControl.m_ShowDivider = true;
        camControl.m_ShowReticle = true;
        camControl.m_ShowPlayerBadges = true;

        // Ensure GameManager has reference to CameraControl
        GameManager gm = Object.FindFirstObjectByType<GameManager>();
        if (gm != null)
        {
            gm.m_CameraControl = camControl;
            EditorUtility.SetDirty(gm);
        }

        Debug.Log("--- 2. Unpacking LevelArt Prefab Instance ---");
        GameObject levelArt = GameObject.Find("LevelArt");
        if (levelArt != null && PrefabUtility.IsPartOfAnyPrefab(levelArt))
        {
            PrefabUtility.UnpackPrefabInstance(levelArt, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Debug.Log("Unpacked LevelArt successfully");
        }

        Debug.Log("--- 3. Repositioning All Decorations on Map ---");
        Dictionary<string, TransformData> transforms = GetNewTransformMap();

        int updatedCount = 0;
        foreach (var entry in transforms)
        {
            GameObject target = FindInHierarchy(levelArt.transform, entry.Key);
            if (target != null)
            {
                Undo.RecordObject(target.transform, "Rearrange Map Decor");
                target.transform.localPosition = entry.Value.pos;
                target.transform.localEulerAngles = entry.Value.rot;
                target.transform.localScale = entry.Value.scale;
                EditorUtility.SetDirty(target.transform);
                updatedCount++;
            }
            else
            {
                Debug.LogWarning($"Decoration object not found: {entry.Key}");
            }
        }
        Debug.Log($"Successfully updated {updatedCount} / {transforms.Count} decoration objects!");

        // Verify SpawnPoints remain intact
        GameObject sp1 = GameObject.Find("SpawnPoint1");
        GameObject sp2 = GameObject.Find("SpawnPoint2");
        Debug.Log($"Verified SpawnPoint1: {(sp1 != null ? sp1.transform.position.ToString() : "MISSING")}");
        Debug.Log($"Verified SpawnPoint2: {(sp2 != null ? sp2.transform.position.ToString() : "MISSING")}");

        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        AssetDatabase.SaveAssets();
        Debug.Log("=== SAVED Main.unity SUCCESSFULLY! ===");
    }

    private static GameObject FindInHierarchy(Transform root, string pathOrName)
    {
        // Try direct child path if contains '/'
        if (pathOrName.Contains("/"))
        {
            Transform t = root.Find(pathOrName);
            if (t != null) return t.gameObject;
        }

        // Recursively find child by name
        return FindChildRecursive(root, pathOrName);
    }

    private static GameObject FindChildRecursive(Transform current, string name)
    {
        if (current.name == name)
            return current.gameObject;

        for (int i = 0; i < current.childCount; i++)
        {
            GameObject found = FindChildRecursive(current.GetChild(i), name);
            if (found != null) return found;
        }
        return null;
    }

    private static Dictionary<string, TransformData> GetNewTransformMap()
    {
        var d = new Dictionary<string, TransformData>();

        // === MILITARY BUILDINGS ===
        // Center battlefield corridor & fortified outpost
        d["Building01"]     = new TransformData(-7.0f, 0.0f, 16.0f,  0f, 90f, 0f,   1f, 1f, 1f);
        d["Building02"]     = new TransformData(7.0f, 0.0f, 9.0f,    0f, 270f, 0f,  1f, 1f, 1f);
        d["Building01 (1)"] = new TransformData(14.0f, 0.0f, 3.0f,   0f, 135f, 0f,  1f, 1f, 1f);
        d["Building02 (1)"] = new TransformData(-14.0f, 0.0f, 22.0f, 0f, 315f, 0f,  1f, 1f, 1f);
        d["Building01 (2)"] = new TransformData(-20.0f, 0.0f, 28.0f, 0f, 45f, 0f,   1f, 1f, 1f);
        d["Building02 (2)"] = new TransformData(22.0f, 0.0f, -6.0f,  0f, 225f, 0f,  1f, 1f, 1f);
        d["Building01 (3)"] = new TransformData(-22.0f, 0.0f, -4.0f, 0f, 135f, 0f,  1f, 1f, 1f);
        d["Radar"]          = new TransformData(0.0f, 0.0f, 12.5f,   0f, 45f, 0f,   1f, 1f, 1f);

        // === OILFIELD (EAST SECTOR) ===
        d["Refinery"]       = new TransformData(27.0f, 0.0f, 12.5f,  0f, 270f, 0f,  1f, 1f, 1f);
        d["OilStorage"]     = new TransformData(23.0f, 0.0f, 24.0f,  0f, 0f, 0f,    1.75f, 1.75f, 1.75f);
        d["OilStorage (1)"] = new TransformData(23.0f, 0.0f, 1.0f,   0f, 0f, 0f,    1.75f, 1.75f, 1.75f);
        d["PumpJack"]       = new TransformData(33.0f, 0.0f, 22.0f,  0f, 30f, 0f,   1f, 1f, 1f);
        d["PumpJack (1)"]   = new TransformData(33.0f, 0.0f, 3.0f,   0f, 30f, 0f,   1f, 1f, 1f);
        d["PumpJack (2)"]   = new TransformData(31.0f, 0.0f, -12.0f, 0f, 30f, 0f,   1f, 1f, 1f);

        // === RUINS, OASIS & HELIPAD (WEST SECTOR) ===
        d["Helipad"]        = new TransformData(-28.0f, 0.0f, -18.0f, 0f, 0f, 0f,   1f, 1f, 1f);
        d["Ruins01"]        = new TransformData(-22.0f, 0.03f, 17.0f, 0f, 35f, 0f,  1f, 1f, 1f);
        d["Ruins01 (1)"]    = new TransformData(-25.0f, 0.03f, 7.0f,  0f, 135f, 0f, 1.28f, 1.28f, 1.28f);
        d["BustedTank"]     = new TransformData(-19.0f, 0.0f, 12.0f,  0f, 150f, 0f, 1f, 1f, 1f);
        d["Crater01"]       = new TransformData(-24.0f, 0.0f, 12.0f,  0f, 10f, 0f,  0.9f, 0.9f, 0.9f);
        d["Crater01 (1)"]   = new TransformData(-17.0f, 0.0f, 14.0f,  0f, 80f, 0f,  0.5f, 0.5f, 0.5f);
        d["Crater01 (2)"]   = new TransformData(-21.0f, 0.0f, 6.0f,   0f, 50f, 0f,  0.45f, 0.45f, 0.45f);
        d["Crater01 (3)"]   = new TransformData(-27.0f, 0.0f, 19.0f,  0f, 30f, 0f,  0.5f, 0.5f, 0.5f);

        // === ANCIENT COLUMNS ===
        d["Column01"]       = new TransformData(-17.0f, 0.0f, 24.0f,  0f, 20f, 0f,  1f, 1f, 1f);
        d["Column01 (1)"]   = new TransformData(-17.0f, 0.0f, 18.0f,  0f, 65f, 0f,  1f, 1f, 1f);
        d["Column01 (2)"]   = new TransformData(-17.0f, 0.0f, 6.0f,   0f, 110f, 0f, 0.9f, 0.9f, 0.9f);
        d["Column02"]       = new TransformData(-17.0f, 0.0f, 0.0f,   0f, 40f, 0f,  0.9f, 0.9f, 0.9f);
        d["Column02 (2)"]   = new TransformData(-29.0f, 0.0f, 14.0f,  0f, 160f, 0f, 0.95f, 0.95f, 0.95f);
        d["Column02 (3)"]   = new TransformData(-29.0f, 0.0f, 8.0f,   0f, 220f, 0f, 0.95f, 0.95f, 0.95f);

        // === DECIDUOUS TREES (10) ===
        d["Tree"]           = new TransformData(-2.0f, 0.0f, 36.0f,  0f, 15f, 0f,   1.1f, 1.1f, 1.1f);
        d["Tree (1)"]       = new TransformData(-9.0f, 0.0f, 34.0f,  0f, 140f, 0f,  0.9f, 0.9f, 0.9f);
        d["Tree (2)"]       = new TransformData(6.0f, 0.0f, 34.0f,   0f, 80f, 0f,   1.0f, 1.0f, 1.0f);
        d["Tree (3)"]       = new TransformData(14.0f, 0.0f, -12.0f, 0f, 200f, 0f,  1.1f, 1.1f, 1.1f);
        d["Tree (4)"]       = new TransformData(7.0f, 0.0f, -11.0f,  0f, 30f, 0f,   0.85f, 0.85f, 0.85f);
        d["Tree (5)"]       = new TransformData(20.0f, 0.0f, -10.0f, 0f, 260f, 0f,  1.2f, 1.2f, 1.2f);
        d["Tree (6)"]       = new TransformData(-10.0f, 0.0f, 23.0f, 0f, 90f, 0f,   1.0f, 1.0f, 1.0f);
        d["Tree (7)"]       = new TransformData(10.0f, 0.0f, 2.0f,   0f, 190f, 0f,  0.9f, 0.9f, 0.9f);
        d["Tree (8)"]       = new TransformData(2.0f, 0.0f, 22.0f,   0f, 45f, 0f,   1.05f, 1.05f, 1.05f);
        d["Tree (9)"]       = new TransformData(-2.0f, 0.0f, 3.0f,   0f, 310f, 0f,  1.0f, 1.0f, 1.0f);

        // === PALM TREES (10) ===
        d["PalmTree"]       = new TransformData(-21.0f, 0.0f, 22.0f, 355f, 30f, 5f,   1.0f, 1.0f, 1.0f);
        d["PalmTree (1)"]   = new TransformData(-23.0f, 0.0f, 24.0f, 8f, 120f, 350f,  0.85f, 0.85f, 0.85f);
        d["PalmTree (2)"]   = new TransformData(-28.0f, 0.0f, 22.0f, 350f, 200f, 10f, 0.95f, 0.95f, 0.95f);
        d["PalmTree (3)"]   = new TransformData(-31.0f, 0.0f, 17.0f, 5f, 85f, 0f,     0.8f, 0.8f, 0.8f);
        d["PalmTree (4)"]   = new TransformData(-30.0f, 0.0f, 3.0f,  352f, 270f, 8f,  0.9f, 0.9f, 0.9f);
        d["PalmTree (5)"]   = new TransformData(-22.0f, 0.0f, -2.0f, 10f, 315f, 350f, 0.75f, 0.75f, 0.75f);
        d["PalmTree (6)"]   = new TransformData(-26.0f, 0.0f, -3.0f, 355f, 45f, 5f,   0.85f, 0.85f, 0.85f);
        d["PalmTree (7)"]   = new TransformData(-32.0f, 0.0f, -12.0f,0f, 140f, 8f,    0.7f, 0.7f, 0.7f);
        d["PalmTree (8)"]   = new TransformData(-22.0f, 0.0f, -14.0f,5f, 220f, 0f,    0.8f, 0.8f, 0.8f);
        d["PalmTree (9)"]   = new TransformData(-33.0f, 0.0f, -24.0f,352f, 350f, 8f,  1.0f, 1.0f, 1.0f);

        // === CACTI (4) ===
        d["Cactus"]         = new TransformData(-28.0f, 0.04f, -7.0f, 0f, 100f, 0f, 0.6f, 0.6f, 0.6f);
        d["Cactus (1)"]     = new TransformData(15.0f, 0.04f, 28.0f,  0f, 40f, 0f,  0.7f, 0.7f, 0.7f);
        d["Cactus (2)"]     = new TransformData(16.0f, 0.04f, -8.0f,  0f, 210f, 0f, 0.65f, 0.65f, 0.65f);
        d["Cactus (3)"]     = new TransformData(-32.0f, 0.04f, 26.0f, 0f, 320f, 0f, 0.8f, 0.8f, 0.8f);

        // === COWS (2) ===
        d["Cow"]            = new TransformData(-7.0f, -0.01f, 32.0f, 0f, 120f, 0f, 1.2f, 1.2f, 1.2f);
        d["Cow (1)"]        = new TransformData(9.0f, -0.01f, -9.0f,  0f, 290f, 0f, 1.2f, 1.2f, 1.2f);

        // === CONCRETE BASES ===
        d["Concrete"]       = new TransformData(0.0f, 0.0f, 12.5f,   0f, 45f, 0f,   1.5f, 1f, 1.5f);
        d["Concrete (1)"]   = new TransformData(-7.0f, 0.0f, 16.0f,  0f, 90f, 0f,   1.4f, 1f, 1.4f);
        d["Concrete (2)"]   = new TransformData(7.0f, 0.0f, 9.0f,    0f, 270f, 0f,  1.4f, 1f, 1.4f);
        d["Concrete (3)"]   = new TransformData(23.0f, 0.0f, 24.0f,  0f, 0f, 0f,    1.5f, 1f, 1.5f);
        d["Concrete (4)"]   = new TransformData(23.0f, 0.0f, 1.0f,   0f, 0f, 0f,    1.5f, 1f, 1.5f);
        d["Concrete (5)"]   = new TransformData(27.0f, 0.0f, 12.5f,  0f, 270f, 0f,  1.8f, 1f, 1.8f);
        d["Concrete (6)"]   = new TransformData(-14.0f, 0.0f, 22.0f, 0f, 315f, 0f,  1.3f, 1f, 1.3f);
        d["Concrete (7)"]   = new TransformData(14.0f, 0.0f, 3.0f,   0f, 135f, 0f,  1.3f, 1f, 1.3f);
        d["Concrete (8)"]   = new TransformData(-28.0f, 0.0f, -18.0f,0f, 0f, 0f,    1.6f, 1f, 1.6f);

        // === ROCKS & BOULDERS ===
        d["Rocks01"]        = new TransformData(1.0f, 0.0f, 16.0f,   0f, 45f, 0f,   0.7f, 0.7f, 0.7f);
        d["Rocks01 (1)"]    = new TransformData(-1.0f, 0.0f, 8.0f,   0f, 130f, 0f,  0.7f, 0.7f, 0.7f);
        d["Rocks01 (2)"]    = new TransformData(18.0f, 0.0f, 14.0f,  0f, 200f, 0f,  0.8f, 0.8f, 0.8f);
        d["Rocks01 (3)"]    = new TransformData(-18.0f, 0.0f, 10.0f, 0f, 15f, 0f,   0.6f, 0.6f, 0.6f);
        d["Rocks01 (4)"]    = new TransformData(30.0f, 0.0f, 28.0f,  0f, 85f, 0f,   0.75f, 0.75f, 0.75f);
        d["Rocks02"]        = new TransformData(4.0f, 0.0f, 14.0f,   0f, 60f, 0f,   0.9f, 0.9f, 0.9f);
        d["Rocks02 (1)"]    = new TransformData(-4.0f, 0.0f, 10.0f,  0f, 240f, 0f,  0.9f, 0.9f, 0.9f);
        d["Rocks02 (2)"]    = new TransformData(16.0f, 0.0f, 22.0f,  0f, 110f, 0f,  0.8f, 0.8f, 0.8f);
        d["Rocks02 (3)"]    = new TransformData(-15.0f, 0.0f, 2.0f,  0f, 320f, 0f,  0.85f, 0.85f, 0.85f);
        d["Rocks02 (4)"]    = new TransformData(28.0f, 0.0f, -4.0f,  0f, 180f, 0f,  0.9f, 0.9f, 0.9f);
        d["Rocks02 (5)"]    = new TransformData(33.0f, 0.0f, 12.0f,  0f, 75f, 0f,   0.8f, 0.8f, 0.8f);
        d["Rocks03"]        = new TransformData(-12.0f, 0.0f, 15.0f, 0f, 20f, 0f,   0.9f, 0.9f, 0.9f);
        d["Rocks03 (2)"]    = new TransformData(12.0f, 0.0f, 9.0f,   0f, 200f, 0f,  0.9f, 0.9f, 0.9f);
        d["Rocks03 (3)"]    = new TransformData(33.0f, 0.0f, -22.0f, 0f, 340f, 0f,  0.95f, 0.95f, 0.95f);
        d["Rocks03 (4)"]    = new TransformData(-32.0f, 0.0f, 32.0f, 0f, 150f, 0f,  1.0f, 1.0f, 1.0f);
        d["Rocks03 (5)"]    = new TransformData(-33.0f, 0.0f, -32.0f,0f, 40f, 0f,   0.7f, 0.7f, 0.7f);
        d["Rocks03 (6)"]    = new TransformData(32.0f, 0.0f, 32.0f,  0f, 90f, 0f,   0.6f, 0.6f, 0.6f);
        d["Rocks03 (7)"]    = new TransformData(32.0f, 0.0f, -32.0f, 0f, 220f, 0f,  0.6f, 0.6f, 0.6f);

        // === PERIMETER DUNES ===
        d["Dunes01"]        = new TransformData(-15.9f, 0.0f, -2.9f, 0f, 278f, 0f,  0.67f, 0.41f, 0.67f);
        d["Dunes01 (1)"]    = new TransformData(-19.6f, 0.0f, 6.9f,  0f, 114f, 0f,  0.77f, 0.32f, 0.77f);
        d["Dunes01 (2)"]    = new TransformData(-20.2f, 0.0f, 12.5f, 0f, 95f, 0f,   0.66f, 0.48f, 0.66f);
        d["Dunes01 (3)"]    = new TransformData(-33.7f, 0.0f, 0.8f,  0f, 309f, 0f,  0.67f, 0.41f, 0.67f);
        d["Dunes01 (4)"]    = new TransformData(25.5f, 0.0f, 15.3f,  0f, 283f, 0f,  0.67f, 0.21f, 0.67f);
        d["Dunes01 (5)"]    = new TransformData(-26.5f, 0.0f, 23.4f, 0f, 280f, 0f,  0.66f, 0.48f, 0.66f);
        d["Dunes01 (6)"]    = new TransformData(-30.4f, 0.0f, 17.4f, 0f, 149f, 0f,  0.77f, 0.32f, 0.77f);
        d["Dunes01 (7)"]    = new TransformData(18.7f, 0.0f, 17.6f,  0f, 65f, 0f,   0.77f, 0.32f, 0.77f);
        d["Dunes01 (8)"]    = new TransformData(23.2f, 0.0f, 32.7f,  0f, 104f, 0f,  0.66f, 0.29f, 0.66f);
        d["Dunes01 (9)"]    = new TransformData(-7.1f, 0.0f, -12.1f, 0f, 278f, 0f,  0.67f, 0.53f, 0.67f);
        d["Dunes01 (10)"]   = new TransformData(-31.4f, 0.0f, -16.1f,0f, 74f, 0f,   0.77f, 0.32f, 0.77f);
        d["Dunes01 (11)"]   = new TransformData(27.2f, 0.0f, -5.6f,  0f, 147f, 0f,  0.67f, 0.53f, 0.67f);
        d["Dunes02"]        = new TransformData(17.7f, 0.0f, 28.2f,  0f, 293f, 0f,  1.0f, 0.33f, 1.0f);
        d["Dunes02 (1)"]    = new TransformData(-21.7f, 0.0f, 18.9f, 0f, 288f, 0f,  1.0f, 0.54f, 1.0f);
        d["Dunes02 (2)"]    = new TransformData(-26.1f, 0.0f, -11.7f,0f, 122f, 0f,  1.0f, 0.54f, 1.0f);
        d["Dunes02 (3)"]    = new TransformData(-37.1f, 0.0f, 5.6f,  0f, 313f, 0f,  1.0f, 0.54f, 1.0f);
        d["Dunes02 (4)"]    = new TransformData(-37.0f, 0.0f, 16.0f, 0f, 124f, 0f,  1.0f, 0.54f, 1.0f);
        d["Dunes02 (5)"]    = new TransformData(-27.1f, 0.0f, -5.1f, 0f, 307f, 0f,  1.0f, 0.70f, 1.0f);
        d["Dunes02 (6)"]    = new TransformData(-11.7f, 0.0f, -12.5f,0f, 122f, 0f,  1.0f, 0.54f, 1.0f);
        d["Dunes02 (7)"]    = new TransformData(-6.8f, 0.0f, -29.0f, 0f, 307f, 0f,  1.0f, 0.54f, 1.0f);

        return d;
    }
}
