using UnityEngine;

/// <summary>
/// Patrol flight controller for background ambient combat helicopter.
/// Creates a lifelike continuous patrol flight with aerodynamic banking, pitch, and hover bobbing.
/// </summary>
public class HelicopterFlight : MonoBehaviour
{
    [Header("Patrol Area")]
    public Vector3 m_Center = new Vector3(0f, 14f, 0f);
    public float m_RadiusX = 28f;
    public float m_RadiusZ = 26f;
    public float m_FlightSpeed = 10f; // m/s
    public bool m_FigureEight = false;

    [Header("Flight Dynamics & Aerodynamics")]
    public float m_ForwardPitch = 9f; // Nose-down tilt when cruising forward
    public float m_MaxBankAngle = 20f; // Roll angle during turns
    public float m_TurnSmooth = 4f;

    [Header("Hover Bobbing / Turbulence")]
    public float m_BobAmplitude = 0.5f;
    public float m_BobFrequency = 2.0f;
    public float m_SwayAmplitude = 0.25f;
    public float m_SwayFrequency = 1.4f;

    private float m_Progress = 0f;
    private Vector3 m_LastPos;

    private void Start()
    {
        m_LastPos = CalculatePathPosition(0f);
        transform.position = m_LastPos;
    }

    private void Update()
    {
        float dt = Time.deltaTime;

        // Path perimeter roughly 2 * pi * average_radius
        float avgRadius = (m_RadiusX + m_RadiusZ) * 0.5f;
        float pathLength = 2f * Mathf.PI * avgRadius;
        if (m_FigureEight) pathLength *= 1.4f;

        m_Progress += (m_FlightSpeed / Mathf.Max(pathLength, 1f)) * dt;
        if (m_Progress > 1f) m_Progress -= 1f;

        // Calculate current and future path position for tangent direction
        Vector3 targetPos = CalculatePathPosition(m_Progress);
        Vector3 lookAheadPos = CalculatePathPosition(m_Progress + 0.015f);

        // Add hover bobbing & wind turbulence
        float bob = Mathf.Sin(Time.time * m_BobFrequency) * m_BobAmplitude;
        float sway = Mathf.Cos(Time.time * m_SwayFrequency) * m_SwayAmplitude;
        targetPos.y += bob;
        targetPos += transform.right * sway;

        transform.position = targetPos;

        // Calculate heading and banking
        Vector3 forwardDir = (lookAheadPos - targetPos).normalized;
        forwardDir.y = 0f;

        if (forwardDir.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(forwardDir, Vector3.up);

            // Compute turn rate to derive banking (roll)
            Vector3 prevForward = (targetPos - m_LastPos).normalized;
            prevForward.y = 0f;
            float turnAngle = Vector3.SignedAngle(prevForward, forwardDir, Vector3.up);
            float bankTarget = Mathf.Clamp(turnAngle * 8f, -m_MaxBankAngle, m_MaxBankAngle);

            // Compose pitch (nose down), yaw (heading), and roll (banking)
            Quaternion aerodynRot = targetRot * Quaternion.Euler(m_ForwardPitch, 0f, -bankTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, aerodynRot, dt * m_TurnSmooth);
        }

        m_LastPos = targetPos;
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
