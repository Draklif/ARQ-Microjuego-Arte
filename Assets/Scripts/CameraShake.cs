using UnityEngine;

// CameraShake: sacude la cámara un instante para dar peso a un evento. Va en la Main Camera.
public class CameraShake : MonoBehaviour
{
    // shortcut: acceso global simple, igual que Level.Instance.
    public static CameraShake Instance { get; private set; }

    Vector3 startPosition;
    float strength;
    float duration;
    float timeLeft;

    void Awake()
    {
        Instance = this;
        startPosition = transform.localPosition;
    }

    public void Shake(float newStrength, float newDuration)
    {
        // Una sacudida débil no interrumpe a una más fuerte que sigue en curso.
        if (timeLeft > 0 && newStrength < strength) return;

        strength = newStrength;
        duration = newDuration;
        timeLeft = newDuration;
    }

    // LateUpdate corre después de todos los Update: la cámara se mueve al final del frame.
    void LateUpdate()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            float fade = Mathf.Clamp01(timeLeft / duration);
            transform.localPosition = startPosition + (Vector3)(Random.insideUnitCircle * strength * fade);
        }
        else
        {
            transform.localPosition = startPosition;
        }
    }
}
