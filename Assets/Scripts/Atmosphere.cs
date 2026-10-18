using UnityEngine;
using UnityEngine.Rendering;

// Atmosphere: un "preset" de estética. Mismo juego, mismas reglas: solo cambian estos datos.
// Se crea con Create > Microjuego > Atmosphere y se edita en el Inspector, sin tocar código.
[CreateAssetMenu(menuName = "Microjuego/Atmosphere")]
public class Atmosphere : ScriptableObject
{
    [Header("Luz")]
    public Color globalLightColor = Color.white;
    public float globalLightIntensity = 0.25f;
    public Color playerLightColor = Color.white;
    public float playerLightIntensity = 2f;
    public float playerLightRadius = 6f;
    [Range(0, 1)] public float playerLightFlicker;

    [Header("Ambiente")]
    public Color backgroundColor = Color.black;
    public VolumeProfile postProcessing;
    public Color textColor = Color.white;

    [Header("Ritmo")]
    public float playerSpeed = 5f;

    [Header("Sonido")]
    public AudioClip music;
    [Range(0, 1)] public float musicVolume = 0.5f;
    public float sfxPitch = 1f;
}
