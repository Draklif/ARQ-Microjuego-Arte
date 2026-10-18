using UnityEngine;

// SoundPlayer: reproduce efectos de sonido 2D. Va en la Main Camera junto a un AudioSource.
// Si el sonido saliera de la moneda, se cortaría al destruirla; desde aquí suena completo.
[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    // shortcut: acceso global simple, igual que Level.Instance y CameraShake.Instance.
    public static SoundPlayer Instance { get; private set; }

    AudioSource source;
    AudioSource music;

    void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
        // Un segundo AudioSource solo para la música en bucle.
        music = gameObject.AddComponent<AudioSource>();
        music.loop = true;
    }

    public void Play(AudioClip clip)
    {
        // PlayOneShot permite que varios sonidos se superpongan sin cortarse.
        source.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip, float volume)
    {
        music.volume = volume;
        if (music.clip == clip) return;

        music.clip = clip;
        if (clip != null) music.Play();
        else music.Stop();
    }

    // Más agudo suena más ligero y alegre; más grave, más pesado y amenazante.
    public void SetPitch(float pitch)
    {
        source.pitch = pitch;
    }
}
