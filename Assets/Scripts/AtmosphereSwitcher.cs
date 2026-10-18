using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

// AtmosphereSwitcher: herramienta de debug. Con Tab pasa a la siguiente atmósfera en vivo.
// Aplica los datos de un Atmosphere a luces, cámara, post procesado, Pawn y sonido.
public class AtmosphereSwitcher : MonoBehaviour
{
    [SerializeField] Atmosphere[] atmospheres;
    [SerializeField] Light2D globalLight;
    [SerializeField] Light2D playerLight;
    [SerializeField] Camera mainCamera;
    [SerializeField] Volume volume;
    [SerializeField] Pawn pawn;
    [SerializeField] TMP_Text coinText;
    [SerializeField] TMP_Text label;

    // static: la atmósfera elegida se mantiene al pasar de nivel.
    static int current;

    void Start()
    {
        Apply();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.tabKey.wasPressedThisFrame)
        {
            current = (current + 1) % atmospheres.Length;
            Apply();
        }

        // Parpadeo de la luz del jugador. Perlin da un ruido suave: titila en vez de vibrar.
        Atmosphere a = atmospheres[current];
        float noise = Mathf.PerlinNoise(Time.time * 8f, 0f);
        playerLight.intensity = a.playerLightIntensity * (1f - a.playerLightFlicker * noise);
    }

    void Apply()
    {
        Atmosphere a = atmospheres[current];
        globalLight.color = a.globalLightColor;
        globalLight.intensity = a.globalLightIntensity;
        playerLight.color = a.playerLightColor;
        playerLight.pointLightOuterRadius = a.playerLightRadius;
        mainCamera.backgroundColor = a.backgroundColor;
        volume.sharedProfile = a.postProcessing;
        coinText.color = a.textColor;
        pawn.Speed = a.playerSpeed;
        SoundPlayer.Instance.PlayMusic(a.music, a.musicVolume);
        SoundPlayer.Instance.SetPitch(a.sfxPitch);
        label.text = "Atmósfera: " + a.name + "   [Tab]";
    }
}
