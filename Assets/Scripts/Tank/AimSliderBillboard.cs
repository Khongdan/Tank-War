using UnityEngine;

public class AimSliderBillboard : MonoBehaviour
{
    public Transform m_Tank;
    public Vector3 m_Offset = new Vector3(1.35f, 1.8f, -0.1f);

    private void LateUpdate()
    {
        if (m_Tank != null)
        {
            // Position beside the tank at eye level
            transform.position = m_Tank.TransformPoint(m_Offset);

            // Keep the arrow strictly vertical (pointing UP),
            // and orient its front face to face directly behind the tank (towards the 3rd person follow camera)
            transform.rotation = Quaternion.LookRotation(m_Tank.forward, Vector3.up);
        }
    }
}
