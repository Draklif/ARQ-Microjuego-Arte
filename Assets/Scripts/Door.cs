using UnityEngine;

// Door: bloquea el paso hasta que el Level la abre.
public class Door : MonoBehaviour
{
    // Prefab de partículas que aparece al abrirse (se destruye solo al terminar).
    [SerializeField] GameObject openEffect;
    [SerializeField] AudioClip openSound;

    public void Open()
    {
        Instantiate(openEffect, transform.position, Quaternion.identity);
        CameraShake.Instance.Shake(0.2f, 0.3f);
        SoundPlayer.Instance.Play(openSound);
        gameObject.SetActive(false);
    }
}
