using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Legacy fields preserved for compatibility
    public float m_DampTime = 0.2f;
    public float m_ScreenEdgeBuffer = 4f;
    public float m_MinSize = 6.5f;

    [Header("Split Screen Cameras")]
    public Camera m_Camera1;                     // Camera for Player 1 (Left Screen)
    public Camera m_Camera2;                     // Camera for Player 2 (Right Screen)

    [Header("3rd-Person Follow Settings")]
    public float m_Distance = 6.5f;              // Distance behind the tank
    public float m_Height = 3.2f;                // Height above the tank
    public float m_LookAheadDistance = 14.0f;    // Distance ahead of the tank to look towards
    public float m_LookAheadHeight = 1.8f;       // Height of the look-ahead point
    public float m_FollowSpeed = 22.0f;          // Position follow responsiveness
    public float m_TurnSpeed = 18.0f;            // Rotation follow responsiveness
    public float m_FieldOfView = 60.0f;          // Perspective field of view
    public LayerMask m_ObstacleMask = ~0;        // Collision mask for camera obstruction avoidance

    [Header("Split Screen UI")]
    public bool m_ShowDivider = true;            // Draw black dividing line between screens
    public bool m_ShowReticle = true;            // Draw crosshairs for aiming
    public bool m_ShowPlayerBadges = true;       // Draw P1 and P2 badges
    public bool m_ShowChargeMeter = true;        // Draw on-screen upward charging power meter

    [HideInInspector] public Transform[] m_Targets; // Targets supplied by GameManager (Tank 1, Tank 2)

    private Vector3[] m_LastKnownPositions = new Vector3[2];
    private Quaternion[] m_LastKnownRotations = new Quaternion[2];
    private bool m_Initialized = false;

    private void Awake()
    {
        EnsureCameras();
    }

    private void Start()
    {
        EnsureCameras();
    }

    /// <summary>
    /// Configures or dynamically creates the two split-screen cameras.
    /// </summary>
    public void EnsureCameras()
    {
        if (m_Initialized && m_Camera1 != null && m_Camera2 != null)
            return;

        // --- Camera 1 (Player 1 - Left half) ---
        if (m_Camera1 == null)
        {
            Transform c1Transform = transform.Find("Camera1");
            if (c1Transform == null) c1Transform = transform.Find("Main Camera");
            if (c1Transform != null)
            {
                m_Camera1 = c1Transform.GetComponent<Camera>();
            }
            else
            {
                Camera[] existing = GetComponentsInChildren<Camera>();
                if (existing.Length > 0) m_Camera1 = existing[0];
            }

            if (m_Camera1 == null)
            {
                GameObject go1 = new GameObject("Camera1");
                go1.transform.parent = transform;
                m_Camera1 = go1.AddComponent<Camera>();
            }
        }

        m_Camera1.name = "Camera1";
        m_Camera1.rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
        m_Camera1.orthographic = false;
        m_Camera1.fieldOfView = m_FieldOfView;
        m_Camera1.nearClipPlane = 0.3f;
        m_Camera1.farClipPlane = 500f;

        AudioListener al1 = m_Camera1.GetComponent<AudioListener>();
        if (al1 == null) al1 = m_Camera1.gameObject.AddComponent<AudioListener>();
        al1.enabled = true;

        // --- Camera 2 (Player 2 - Right half) ---
        if (m_Camera2 == null)
        {
            Transform c2Transform = transform.Find("Camera2");
            if (c2Transform != null)
            {
                m_Camera2 = c2Transform.GetComponent<Camera>();
            }
            else
            {
                Camera[] existing = GetComponentsInChildren<Camera>();
                for (int i = 0; i < existing.Length; i++)
                {
                    if (existing[i] != m_Camera1)
                    {
                        m_Camera2 = existing[i];
                        break;
                    }
                }
            }

            if (m_Camera2 == null)
            {
                GameObject go2 = new GameObject("Camera2");
                go2.transform.parent = transform;
                m_Camera2 = go2.AddComponent<Camera>();
            }
        }

        m_Camera2.name = "Camera2";
        m_Camera2.rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
        m_Camera2.orthographic = false;
        m_Camera2.fieldOfView = m_FieldOfView;
        m_Camera2.nearClipPlane = 0.3f;
        m_Camera2.farClipPlane = 500f;

        AudioListener al2 = m_Camera2.GetComponent<AudioListener>();
        if (al2 != null)
        {
            al2.enabled = false;
        }

        m_Initialized = true;
    }

    private void LateUpdate()
    {
        EnsureCameras();

        if (m_Targets == null || m_Targets.Length == 0)
            return;

        if (m_Targets.Length > 0 && m_Targets[0] != null)
        {
            UpdateFollowCamera(m_Camera1, 0);
        }

        if (m_Targets.Length > 1 && m_Targets[1] != null)
        {
            UpdateFollowCamera(m_Camera2, 1);
        }
    }

    private void UpdateFollowCamera(Camera cam, int playerIndex)
    {
        if (cam == null || m_Targets == null || playerIndex >= m_Targets.Length)
            return;

        Transform target = m_Targets[playerIndex];
        if (target == null)
            return;

        if (target.gameObject.activeSelf)
        {
            m_LastKnownPositions[playerIndex] = target.position;
            m_LastKnownRotations[playerIndex] = target.rotation;
        }

        Vector3 targetPos = m_LastKnownPositions[playerIndex];
        Quaternion targetRot = m_LastKnownRotations[playerIndex];
        Vector3 forward = targetRot * Vector3.forward;

        Vector3 desiredPos = targetPos - forward * m_Distance + Vector3.up * m_Height;

        Vector3 pivot = targetPos + Vector3.up * 1.5f;
        Vector3 toCam = desiredPos - pivot;
        float dist = toCam.magnitude;
        if (dist > 0.1f)
        {
            RaycastHit hit;
            if (Physics.SphereCast(pivot, 0.3f, toCam.normalized, out hit, dist, m_ObstacleMask))
            {
                if (hit.transform != target && !hit.transform.IsChildOf(target))
                {
                    desiredPos = hit.point + hit.normal * 0.25f;
                }
            }
        }

        cam.transform.position = Vector3.Lerp(cam.transform.position, desiredPos, Time.deltaTime * m_FollowSpeed);

        Vector3 lookTarget = targetPos + forward * m_LookAheadDistance + Vector3.up * m_LookAheadHeight;
        Vector3 lookDir = lookTarget - cam.transform.position;
        if (lookDir != Vector3.zero)
        {
            Quaternion desiredRot = Quaternion.LookRotation(lookDir, Vector3.up);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, desiredRot, Time.deltaTime * m_TurnSpeed);
        }
    }

    /// <summary>
    /// Snaps cameras instantly to the starting positions behind each tank (called by GameManager at round start).
    /// </summary>
    public void SetStartPositionAndSize()
    {
        EnsureCameras();

        if (m_Targets == null || m_Targets.Length == 0)
            return;

        if (m_Targets.Length > 0 && m_Targets[0] != null)
        {
            SnapCamera(m_Camera1, 0);
        }

        if (m_Targets.Length > 1 && m_Targets[1] != null)
        {
            SnapCamera(m_Camera2, 1);
        }
    }

    private void SnapCamera(Camera cam, int playerIndex)
    {
        if (cam == null || m_Targets == null || playerIndex >= m_Targets.Length)
            return;

        Transform target = m_Targets[playerIndex];
        if (target == null)
            return;

        m_LastKnownPositions[playerIndex] = target.position;
        m_LastKnownRotations[playerIndex] = target.rotation;

        Vector3 forward = target.forward;
        Vector3 desiredPos = target.position - forward * m_Distance + Vector3.up * m_Height;
        cam.transform.position = desiredPos;

        Vector3 lookTarget = target.position + forward * m_LookAheadDistance + Vector3.up * m_LookAheadHeight;
        Vector3 lookDir = lookTarget - desiredPos;
        if (lookDir != Vector3.zero)
        {
            cam.transform.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
        }
    }

    private void OnGUI()
    {
        float sw = Screen.width;
        float sh = Screen.height;

        // 1. Draw stylish split-screen vertical divider line
        if (m_ShowDivider)
        {
            float dividerWidth = 4f;
            float cx = (sw - dividerWidth) * 0.5f;

            Color oldColor = GUI.color;
            GUI.color = new Color(0.1f, 0.12f, 0.15f, 0.95f);
            GUI.DrawTexture(new Rect(cx, 0f, dividerWidth, sh), Texture2D.whiteTexture);
            GUI.color = oldColor;
        }

        // 2. Draw aiming reticles for Player 1 and Player 2
        float p1CenterX = sw * 0.25f;
        float p2CenterX = sw * 0.75f;
        float reticleCenterY = sh * 0.52f;

        if (m_ShowReticle)
        {
            DrawAimReticle(p1CenterX, reticleCenterY, new Color(0.3f, 0.7f, 1f, 0.85f));
            DrawAimReticle(p2CenterX, reticleCenterY, new Color(1f, 0.35f, 0.3f, 0.85f));
        }

        // 3. Draw On-Screen Upward Charging Power Meter
        if (m_ShowChargeMeter && m_Targets != null)
        {
            // Player 1 charging meter
            if (m_Targets.Length > 0 && m_Targets[0] != null)
            {
                TankShooting ts1 = m_Targets[0].GetComponent<TankShooting>();
                if (ts1 != null && ts1.IsCharging)
                {
                    DrawChargePowerMeter(p1CenterX + 35f, reticleCenterY, ts1.LaunchForceFraction);
                }
            }

            // Player 2 charging meter
            if (m_Targets.Length > 1 && m_Targets[1] != null)
            {
                TankShooting ts2 = m_Targets[1].GetComponent<TankShooting>();
                if (ts2 != null && ts2.IsCharging)
                {
                    DrawChargePowerMeter(p2CenterX + 35f, reticleCenterY, ts2.LaunchForceFraction);
                }
            }
        }

        // 4. Draw Player Badges
        if (m_ShowPlayerBadges)
        {
            GUIStyle badgeStyle = new GUIStyle(GUI.skin.box);
            badgeStyle.fontSize = 14;
            badgeStyle.fontStyle = FontStyle.Bold;
            badgeStyle.alignment = TextAnchor.MiddleCenter;

            // P1 Badge (Top-left of left screen)
            Color oldColor = GUI.color;
            GUI.color = new Color(0.2f, 0.5f, 1f, 0.9f);
            GUI.Box(new Rect(15f, 15f, 75f, 28f), "PLAYER 1", badgeStyle);

            // P2 Badge (Top-left of right screen)
            float p2Left = (sw * 0.5f) + 15f;
            GUI.color = new Color(1f, 0.3f, 0.25f, 0.9f);
            GUI.Box(new Rect(p2Left, 15f, 75f, 28f), "PLAYER 2", badgeStyle);

            GUI.color = oldColor;
        }
    }

    private void DrawAimReticle(float cx, float cy, Color reticleColor)
    {
        Color oldColor = GUI.color;
        GUI.color = reticleColor;

        float lineLen = 10f;
        float gap = 5f;
        float thickness = 2f;

        // Top tick
        GUI.DrawTexture(new Rect(cx - thickness * 0.5f, cy - gap - lineLen, thickness, lineLen), Texture2D.whiteTexture);
        // Bottom tick
        GUI.DrawTexture(new Rect(cx - thickness * 0.5f, cy + gap, thickness, lineLen), Texture2D.whiteTexture);
        // Left tick
        GUI.DrawTexture(new Rect(cx - gap - lineLen, cy - thickness * 0.5f, lineLen, thickness), Texture2D.whiteTexture);
        // Right tick
        GUI.DrawTexture(new Rect(cx + gap, cy - thickness * 0.5f, lineLen, thickness), Texture2D.whiteTexture);

        // Center dot
        float dotSize = 2.5f;
        GUI.DrawTexture(new Rect(cx - dotSize * 0.5f, cy - dotSize * 0.5f, dotSize, dotSize), Texture2D.whiteTexture);

        GUI.color = oldColor;
    }

    private void DrawChargePowerMeter(float x, float centerY, float fraction)
    {
        float meterW = 12f;
        float meterH = 80f;
        float y = centerY - meterH * 0.5f;

        Color oldColor = GUI.color;

        // Background dark frame
        GUI.color = new Color(0.08f, 0.08f, 0.1f, 0.9f);
        GUI.DrawTexture(new Rect(x - 2, y - 2, meterW + 4, meterH + 4), Texture2D.whiteTexture);

        // Background gauge track
        GUI.color = new Color(0.2f, 0.22f, 0.25f, 0.6f);
        GUI.DrawTexture(new Rect(x, y, meterW, meterH), Texture2D.whiteTexture);

        // Upward charging bar (fills from bottom to top!)
        float fillHeight = fraction * meterH;
        Color barColor = fraction < 0.5f
            ? Color.Lerp(Color.green, Color.yellow, fraction * 2f)
            : Color.Lerp(Color.yellow, Color.red, (fraction - 0.5f) * 2f);

        GUI.color = barColor;
        GUI.DrawTexture(new Rect(x, y + meterH - fillHeight, meterW, fillHeight), Texture2D.whiteTexture);

        // Top tick mark
        GUI.color = Color.white;
        GUI.DrawTexture(new Rect(x, y - 4, meterW, 2), Texture2D.whiteTexture);

        // Percentage text
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
        labelStyle.fontSize = 11;
        labelStyle.fontStyle = FontStyle.Bold;
        labelStyle.normal.textColor = barColor;
        GUI.Label(new Rect(x + meterW + 4, centerY - 10, 45, 20), $"{(int)(fraction * 100)}%", labelStyle);

        GUI.color = oldColor;
    }
}
