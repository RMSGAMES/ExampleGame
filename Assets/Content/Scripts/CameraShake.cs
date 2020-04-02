using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public enum ShakeMode { OnlyX, OnlyY, OnlyZ, XY, XZ, XYZ };

    #region Private
    private static Transform m_transform;
    private static float elapsed, m_duration, m_power, percentComplete;
    private static ShakeMode m_mode;
    private static Vector3 originalPos;
    #endregion

    private void Start()
    {
        percentComplete = 1;
        m_transform = GetComponent<Transform>();
    }

    public static void Shake(float duration, float power)
    {
        if (percentComplete == 1) originalPos = m_transform.localPosition;
        m_mode = ShakeMode.XYZ;
        elapsed = 0;
        m_duration = duration;
        m_power = power;
    }

    public static void Shake(float duration, float power, ShakeMode mode)
    {
        if (percentComplete == 1) originalPos = m_transform.localPosition;
        m_mode = mode;
        elapsed = 0;
        m_duration = duration;
        m_power = power;
    }

    private void Update()
    {
        if (elapsed < m_duration)
        {
            elapsed += Time.deltaTime;
            percentComplete = elapsed / m_duration;
            percentComplete = Mathf.Clamp01(percentComplete);
            Vector3 rnd = Random.insideUnitSphere * m_power * (1f - percentComplete);

            switch (m_mode)
            {
                case ShakeMode.XYZ:
                    m_transform.localPosition = originalPos + rnd;
                    break;
                case ShakeMode.OnlyX:
                    m_transform.localPosition = originalPos + new Vector3(rnd.x, 0, 0);
                    break;
                case ShakeMode.OnlyY:
                    m_transform.localPosition = originalPos + new Vector3(0, rnd.y, 0);
                    break;
                case ShakeMode.OnlyZ:
                    m_transform.localPosition = originalPos + new Vector3(0, 0, rnd.z);
                    break;
                case ShakeMode.XY:
                    m_transform.localPosition = originalPos + new Vector3(rnd.x, rnd.y, 0);
                    break;
                case ShakeMode.XZ:
                    m_transform.localPosition = originalPos + new Vector3(rnd.x, 0, rnd.z);
                    break;
            }
        }
    }
}