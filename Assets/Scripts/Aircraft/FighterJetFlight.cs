using UnityEngine;

/// <summary>
/// Flight controller for ambient combat fighter jets.
/// Produces high-speed flyover sweeps across the battlefield with realistic banking,
/// and manages twin exhaust smoke contrails that dissipate cleanly between flyover passes.
/// </summary>
public class FighterJetFlight : MonoBehaviour
{
    [Header("Flight Path (When Independent)")]
    public Vector3 m_Center = new Vector3(0f, 25f, 0f);
    public float m_RadiusX = 42f;
    public float m_RadiusZ = 36f;
    public float m_Speed = 28f; // m/s
    public float m_PhaseOffset = 0f; // 0 to 1
    public bool m_FigureEight = false;

    [Header("Formation Wingman Mode")]
    [Tooltip("If assigned, this jet flies as wingman relative to the leader")]
    public Transform m_Leader;
    public Vector3 m_FormationOffset = new Vector3(8f, 1.5f, -10f);
    public float m_FormationLag = 8f;

    [Header("Aerodynamics & Banking")]
    public float m_MaxBankAngle = 55f; // Sharp military combat banking
    public float m_TurnSmooth = 5f;

    [Header("Smoke Trails (Contrails)")]
    [Tooltip("Twin engine exhaust trail renderers")]
    public TrailRenderer[] m_SmokeTrails;
    [Tooltip("Duration in seconds for smoke to linger and fully dissipate")]
    public float m_TrailDuration = 3.5f;
    [Tooltip("Emit smoke only when flying inside the battlefield zone")]
    public bool m_EmitOverMapOnly = true;
    public float m_MapBoundaryX = 38f;
    public float m_MapBoundaryZ = 38f;

    private float m_Progress = 0f;
    private Vector3 m_LastPos;

    private void Start()
    {
        m_Progress = m_PhaseOffset;

        // Configure trail duration on start
        if (m_SmokeTrails != null)
        {
            foreach (var trail in m_SmokeTrails)
            {
                if (trail != null)
                {
                    trail.time = m_TrailDuration;
                    trail.emitting = false;
                }
            }
        }

        if (m_Leader == null)
        {
            m_LastPos = CalculatePathPosition(m_Progress);
            transform.position = m_LastPos;
        }
        else
        {
            m_LastPos = m_Leader.TransformPoint(m_FormationOffset);
            transform.position = m_LastPos;
        }
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        Vector3 targetPos;
        Vector3 lookAheadPos;

        if (m_Leader != null)
        {
            // Follow leader in tactical formation
            targetPos = m_Leader.TransformPoint(m_FormationOffset);
            transform.position = Vector3.Lerp(transform.position, targetPos, dt * m_FormationLag);
            transform.rotation = Quaternion.Slerp(transform.rotation, m_Leader.rotation, dt * m_FormationLag);
            targetPos = transform.position;
        }
        else
        {
            // Independent parametric loop
            float avgRadius = (m_RadiusX + m_RadiusZ) * 0.5f;
            float pathLength = 2f * Mathf.PI * avgRadius;
            if (m_FigureEight) pathLength *= 1.4f;

            m_Progress += (m_Speed / Mathf.Max(pathLength, 1f)) * dt;
            if (m_Progress > 1f) m_Progress -= 1f;

            targetPos = CalculatePathPosition(m_Progress);
            lookAheadPos = CalculatePathPosition(m_Progress + 0.012f);

            transform.position = targetPos;

            // Compute forward direction and combat banking
            Vector3 forwardDir = (lookAheadPos - targetPos).normalized;
            if (forwardDir.sqrMagnitude > 0.001f)
            {
                Quaternion targetRot = Quaternion.LookRotation(forwardDir, Vector3.up);

                Vector3 prevForward = (targetPos - m_LastPos).normalized;
                float turnAngle = Vector3.SignedAngle(prevForward, forwardDir, Vector3.up);
                float bankTarget = Mathf.Clamp(turnAngle * 14f, -m_MaxBankAngle, m_MaxBankAngle);

                Quaternion aerodynRot = targetRot * Quaternion.Euler(0f, 0f, -bankTarget);
                transform.rotation = Quaternion.Slerp(transform.rotation, aerodynRot, dt * m_TurnSmooth);
            }
        }

        // Manage smoke contrail emission based on arena boundaries
        UpdateSmokeTrails(transform.position);

        m_LastPos = transform.position;
    }

    private void UpdateSmokeTrails(Vector3 currentPos)
    {
        if (m_SmokeTrails == null) return;

        bool shouldEmit = true;
        if (m_EmitOverMapOnly)
        {
            // Emit while crossing inside map boundaries; stop during the outer reset loop
            shouldEmit = Mathf.Abs(currentPos.x) <= m_MapBoundaryX && Mathf.Abs(currentPos.z) <= m_MapBoundaryZ;
        }

        foreach (var trail in m_SmokeTrails)
        {
            if (trail != null)
            {
                if (trail.emitting != shouldEmit)
                {
                    trail.emitting = shouldEmit;
                }
            }
        }
    }

    private Vector3 CalculatePathPosition(float t)
    {
        float angle = t * Mathf.PI * 2f;
        float x, z;

        if (m_FigureEight)
        {
            x = m_Center.x + Mathf.Sin(angle) * m_RadiusX;
            z = m_Center.z + (Mathf.Sin(angle * 2f) * 0.5f) * m_RadiusZ;
        }
        else
        {
            x = m_Center.x + Mathf.Sin(angle) * m_RadiusX;
            z = m_Center.z + Mathf.Cos(angle) * m_RadiusZ;
        }

        return new Vector3(x, m_Center.y, z);
    }
}
