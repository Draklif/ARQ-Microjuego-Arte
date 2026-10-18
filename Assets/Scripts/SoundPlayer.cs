using UnityEngine;

// SoundPlayer: reproduce efectos de sonido 2D. Va en la Main Camera junto a un AudioSource.
// Si el sonido saliera de la moneda, se cortaría al destruirla; desde aquí suena completo.
[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    // shortcut: acceso global simple, igual que Level.Instance y CameraShake.Instance.
    public static SoundPlayer Instance { get; private set; }

    AudioSource source;

    void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        // PlayOneShot permite que varios sonidos se superpongan sin cortarse.
        source.PlayOneShot(clip);
    }
}
