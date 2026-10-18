using UnityEngine;

// Coin: necesita un Collider2D con "Is Trigger" activado.
public class Coin : MonoBehaviour
{
    // Prefab de partículas que aparece al recogerla (se destruye solo al terminar).
    [SerializeField] GameObject pickupEffect;
    [SerializeField] AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Solo un Pawn puede recoger monedas.
        if (other.GetComponent<Pawn>() == null) return;

        Level.Instance.AddCoin();
        Instantiate(pickupEffect, transform.position, Quaternion.identity);
        CameraShake.Instance.Shake(0.05f, 0.1f);
        SoundPlayer.Instance.Play(pickupSound);
        Destroy(gameObject);
    }
}
