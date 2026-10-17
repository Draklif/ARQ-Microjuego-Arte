using UnityEngine;

// Coin: necesita un Collider2D con "Is Trigger" activado.
public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Solo un Pawn puede recoger monedas.
        if (other.GetComponent<Pawn>() == null) return;

        Level.Instance.AddCoin();
        Destroy(gameObject);
    }
}
