using UnityEngine;

/// <summary>
/// Controls high-speed spinning of helicopter main rotor and tail rotor blades.
/// </summary>
public class HelicopterRotor : MonoBehaviour
{
    [Header("Rotor Transforms")]
    [Tooltip("Transform of the main rotor (rotates around local Y axis)")]
    public Transform m_MainRotor;

    [Tooltip("Transform of the tail rotor (rotates around local X axis)")]
    public Transform m_TailRotor;

    [Header("Spin Speeds (Degrees / Sec)")]
    public float m_MainRotorSpeed = 1200f;
    public float m_TailRotorSpeed = 2200f;

    private void Update()
    {
        float dt = Time.deltaTime;

        if (m_MainRotor != null)
        {
            m_MainRotor.Rotate(0f, m_MainRotorSpeed * dt, 0f, Space.Self);
        }

        if (m_TailRotor != null)
        {
            m_TailRotor.Rotate(m_TailRotorSpeed * dt, 0f, 0f, Space.Self);
        }
    }
}
